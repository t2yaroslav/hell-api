﻿using System;
using System.Runtime.InteropServices;

namespace Hell.LastCircle.WinAPI
{
	/// <summary>
	/// NMHDR WinAPI structure.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public class NMHDR
	{
		public IntPtr hwndFrom;
		public UIntPtr idFrom;
		public uint code;
	}
}