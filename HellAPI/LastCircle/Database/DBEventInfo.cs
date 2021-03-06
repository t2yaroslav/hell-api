﻿using System;
using System.Runtime.InteropServices;

namespace Hell.LastCircle.Database
{
	/// <summary>
	/// Mapping of DBEVENTNFO structure. Surprisingly, contains information
	/// about database event.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public class DBEventInfo
	{
		/// <summary>
		/// this is the first event in the chain; internal only: *do not* use
		/// this flag
		/// </summary>
		public const int DBEF_FIRST = 1;

		/// <summary>
		/// this event was sent by the user. If not set this event was
		/// received.
		/// </summary>
		public const int DBEF_SENT = 2;

		/// <summary>
		/// event has been read by the user. It does not need
		/// to be processed any more except for history.
		/// </summary>
		public const int DBEF_READ = 4;

		/// <summary>
		/// event contains the right-to-left aligned text
		/// </summary>
		public const int DBEF_RTL = 8;

		/// <summary>
		/// event contains a text in utf-8
		/// </summary>
		public const int DBEF_UTF = 16;

		public const ushort EVENTTYPE_MESSAGE = 0;
		public const ushort EVENTTYPE_URL = 1;
		public const ushort EVENTTYPE_CONTACTS = 2;
		public const ushort EVENTTYPE_ADDED = 1000;
		public const ushort EVENTTYPE_AUTHREQUEST = 1001;
		public const ushort EVENTTYPE_FILE = 1002;

		/// <summary>
		/// size of the structure in bytes
		/// </summary>
		private int cbSize = Marshal.SizeOf(typeof (DBEventInfo));

		/// <summary>
		/// pointer to name of the module that 'owns' this event, ie the one
		/// that is in control of the data format
		/// </summary>
		public string szModule;

		/// <summary>
		/// seconds since 00:00, 01/01/1970. Gives us times until 2106 unless
		/// you use the standard C library which is signed and can only do
		/// until 2038. In GMT.
		/// </summary>
		public int timestamp;

		/// <summary>
		/// the omnipresent flags
		/// </summary>
		public int flags;

		/// <summary>
		/// module-defined event type field
		/// </summary>
		public ushort eventType;

		/// <summary>
		/// size of pBlob in bytes
		/// </summary>
		public uint cbBlob;

		/// <summary>
		/// pointer to buffer containing module-defined event data
		/// </summary>
		public IntPtr pBlob;
	}
}