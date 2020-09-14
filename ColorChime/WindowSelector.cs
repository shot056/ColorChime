using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ColorChime
{
    public partial class WindowSelector : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr WindowFromPoint(POINT point);
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetAncestor(IntPtr hWnd, uint gaFlags);
        const uint GA_PARENT = 1;
        const uint GA_ROOT = 2;
        const uint GA_ROOTOWNER = 3; // 複数windowを持つ場合は、そのownerが返る


        public delegate bool EnumWindowsDelegate(IntPtr hWnd, IntPtr lparam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern static bool EnumWindows(EnumWindowsDelegate lpEnumFunc, IntPtr lparam);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out POINT lpPoint);

        public enum LsvSortAttr
        {
            byNumeric,
            byHex,
            byString
        };

        List<TopLevelWindowInfo> wndInfos;
        List<LsvSortAttr> sortOrderIdent;

        public TopLevelWindowInfo selectedWindow { get; set; }

        public WindowSelector()
        {
            InitializeComponent();

            wndInfos = new List<TopLevelWindowInfo>();
            sortOrderIdent = new List<LsvSortAttr>();

            lsvWinList.Columns.Add("No", 35, HorizontalAlignment.Left); sortOrderIdent.Add(LsvSortAttr.byNumeric);
            lsvWinList.Columns.Add("HWND", 70, HorizontalAlignment.Left); sortOrderIdent.Add(LsvSortAttr.byHex);
            lsvWinList.Columns.Add("PID", 50, HorizontalAlignment.Left); sortOrderIdent.Add(LsvSortAttr.byNumeric);
            lsvWinList.Columns.Add("WindowText", 150, HorizontalAlignment.Left); sortOrderIdent.Add(LsvSortAttr.byString);
            lsvWinList.Columns.Add("ClassName", 150, HorizontalAlignment.Left); sortOrderIdent.Add(LsvSortAttr.byString);
            lsvWinList.Columns.Add("Left", 45, HorizontalAlignment.Left); sortOrderIdent.Add(LsvSortAttr.byNumeric);
            lsvWinList.Columns.Add("Top", 45, HorizontalAlignment.Left); sortOrderIdent.Add(LsvSortAttr.byNumeric);
            lsvWinList.Columns.Add("Width", 45, HorizontalAlignment.Left); sortOrderIdent.Add(LsvSortAttr.byNumeric);
            lsvWinList.Columns.Add("Height", 45, HorizontalAlignment.Left); sortOrderIdent.Add(LsvSortAttr.byNumeric);
            lsvWinList.Columns.Add("cLeft", 45, HorizontalAlignment.Left); sortOrderIdent.Add(LsvSortAttr.byNumeric);
            lsvWinList.Columns.Add("cTop", 45, HorizontalAlignment.Left); sortOrderIdent.Add(LsvSortAttr.byNumeric);
            lsvWinList.Columns.Add("cWidth", 45, HorizontalAlignment.Left); sortOrderIdent.Add(LsvSortAttr.byNumeric);
            lsvWinList.Columns.Add("cHeight", 45, HorizontalAlignment.Left); sortOrderIdent.Add(LsvSortAttr.byNumeric);
            lsvWinList.Columns.Add("Style", 70, HorizontalAlignment.Left); sortOrderIdent.Add(LsvSortAttr.byHex);

        }

        private void WindowSelector_Load(object sender, EventArgs e)
        {
            EnumWndUpdateList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            EnumWndUpdateList();
        }

        private void chkShowInvisible_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListControl();
        }

        private void lsvWinList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column >= 0 && e.Column < lsvWinList.Columns.Count)
            {
                lsvWinList.ListViewItemSorter = new ListViewItemComparer(e.Column, sortOrderIdent[e.Column]);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lsvWinList.SelectedItems.Count > 0)
            {
                int selectedIdx = Convert.ToInt32(lsvWinList.SelectedItems[0].Text, 10);
                if(wndInfos.Count >= selectedIdx)
                {
                    selectedWindow = wndInfos[selectedIdx - 1];
                    this.DialogResult = DialogResult.OK;
                }

            }
        }

        private void lsvWinList_DoubleClick(object sender, EventArgs e)
        {
            btnSelect_Click(sender, e);
        }

        private void lsvWinList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lsvWinList.SelectedItems.Count > 0)
            {
                btnSelect.Enabled = true;
            }
            else
            {
                btnSelect.Enabled = false;
            }
        }
        
        public class ListViewItemComparer : IComparer
        {
            private int _column;
            private LsvSortAttr _sortAttr;

            public ListViewItemComparer(int col, LsvSortAttr sortAttr)
            {
                _column = col;
                _sortAttr = sortAttr;
            }

            private int CompareInt64(Int64 a, Int64 b)
            {
                if (a < b) { return -1; }
                if (a > b) { return 1; }
                return 0;
            }

            public int Compare(object obj1, object obj2)
            {
                string s1 = ((ListViewItem)obj1).SubItems[_column].Text;
                string s2 = ((ListViewItem)obj2).SubItems[_column].Text;

                if (_sortAttr == LsvSortAttr.byNumeric)
                {
                    Int64 n1;
                    Int64 n2;
                    try
                    {
                        n1 = Convert.ToInt64(s1);
                        n2 = Convert.ToInt64(s2);
                        return CompareInt64(n1, n2);
                    }
                    catch (Exception e) { Console.WriteLine(e); } // catchしたら文字列比較へ
                }
                else if (_sortAttr == LsvSortAttr.byHex)
                {
                    // 未実装.. とりあえず文字列比較
                }
                return string.Compare(s1, s2);
            }
        }

        private bool EnumWindowCallBack(IntPtr hWnd, IntPtr lparam)
        {
            wndInfos.Add(new TopLevelWindowInfo(hWnd));
            return true;        //すべてのウィンドウを列挙する
        }

        public ListViewItem ConvertToListViewItem(int index, TopLevelWindowInfo a)
        {
            var ss = new string[]
            {
            index.ToString(),
            a.hWnd.ToString("X8"),
            a.pid.ToString(),
            a.windowText,
            a.className,
            a.left.ToString(),
            a.top.ToString(),
            a.width.ToString(),
            a.height.ToString(),
            a.clientLeft.ToString(),
            a.clientTop.ToString(),
            a.clientWidth.ToString(),
            a.clientHeight.ToString(),
            a.windowStyle.ToString("X8")
            };

            var t = new ListViewItem(ss);
            t.Tag = a;
            return t;
        }

        void EnumWndUpdateList()
        {
            wndInfos = new List<TopLevelWindowInfo>();

            //ウィンドウを列挙する
            EnumWindows(EnumWindowCallBack, IntPtr.Zero);

            UpdateListControl();

            POINT p = new POINT();
            GetCursorPos(out p);
            IntPtr hWnd = WindowFromPoint(p);
            IntPtr hWndRoot = IntPtr.Zero;

            if (hWnd != IntPtr.Zero)
            {
                hWndRoot = GetAncestor(hWnd, GA_ROOT);
            }

            Console.Write("HWND on cursor = 0x");
            Console.WriteLine(((int)hWndRoot).ToString("X8"));
        }

        void UpdateListControl()
        {
            bool showInvisWnd = chkShowInvisible.Checked;

            lsvWinList.Items.Clear();
            lsvWinList.BeginUpdate();
            try
            {
                int itemNo = 0;
                foreach (var t in wndInfos)
                {
                    itemNo++;
                    if (showInvisWnd || t.IsVisibleWindow())
                    {
                        lsvWinList.Items.Add(ConvertToListViewItem(itemNo, t));
                    }
                }
            }
            finally
            {
                lsvWinList.EndUpdate();
            }
        }

    }

}
