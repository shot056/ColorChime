using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ColorChime
{
    public class TopLevelWindowInfo
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWINFO
        {
            public int cbSize;
            public RECT rcWindow;
            public RECT rcClient;
            public int dwStyle;
            public int dwExStyle;
            public int dwWindowStatus;
            public uint cxWindowBorders;
            public uint cyWindowBorders;
            public short atomWindowType;
            public short wCreatorVersion;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;  // external area. source:  https://docs.microsoft.com/en-us/previous-versions/dd162897(v%3Dvs.85)
            public int bottom; // 
            public int width { get { return right - left; } }
            public int height { get { return bottom - top; } }
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);


        public const int MaxLength = 500;

        IntPtr _hWnd;
        string _className;
        string _windowText;
        WINDOWINFO _wi;
        int _pid;

        public IntPtr hWnd { get { return _hWnd; } }
        public string className { get { return _className; } }
        public string windowText { get { return _windowText; } }
        public int windowStatus { get { return _wi.dwWindowStatus; } }
        public int left { get { return _wi.rcWindow.left; } }
        public int top { get { return _wi.rcWindow.top; } }
        public int width { get { return _wi.rcWindow.width; } }
        public int height { get { return _wi.rcWindow.height; } }

        public int clientLeft { get { return _wi.rcClient.left; } }
        public int clientTop { get { return _wi.rcClient.top; } }
        public int clientWidth { get { return _wi.rcClient.width; } }
        public int clientHeight { get { return _wi.rcClient.height; } }

        public int windowStyle { get { return _wi.dwStyle; } }
        public int pid { get { return _pid; } }

        public TopLevelWindowInfo(IntPtr arg_hWnd)
        {
            int retCode;

            _hWnd = arg_hWnd;

            //ウィンドウのクラス名を取得する
            StringBuilder csb = new StringBuilder(MaxLength);
            retCode = GetClassName(hWnd, csb, csb.Capacity);

            _className = csb.ToString();

            //ウィンドウのタイトルを取得する
            StringBuilder tsb = new StringBuilder(MaxLength);
            retCode = GetWindowText(hWnd, tsb, tsb.Capacity);

            if (retCode > 0)
            {
                _windowText = tsb.ToString();
            }
            else
            {
                _windowText = "";
            }

            _wi = new WINDOWINFO();
            _wi.cbSize = Marshal.SizeOf(_wi);  // sizeof(WINDOWINFO);でもよいようだが sizeof()を使う場合は unsafe{}が必要
            retCode = GetWindowInfo(_hWnd, ref _wi);
            if (retCode == 0)
            {
                Console.WriteLine("GetWindowInfo returns 0.");
            }

            GetWindowThreadProcessId(_hWnd, out _pid);
        }


        const int WS_VISIBLE = 0x10000000;
        const int WS_ICONIC = 0x20000000;

        public bool IsVisibleWindow()
        {
            if ((_wi.dwStyle & WS_VISIBLE) == 0) return false;
            if ((_wi.dwStyle & WS_ICONIC) == WS_ICONIC) return false;
            if (width <= 0 || height <= 0) return false;

            return true;
        }
    }
}
