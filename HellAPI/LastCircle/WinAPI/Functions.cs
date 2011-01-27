﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Hell.LastCircle.WinAPI
{
    /// <summary>
    /// Various useful WinAPI functions.
    /// </summary>
    public class Functions
    {
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 message,
            IntPtr wParam, IntPtr lParam);
    }
}
