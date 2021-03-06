﻿/*
 * Copyright (C) 2010-2011 by ForNeVeR
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Runtime.InteropServices;

namespace Hell
{
    /// <summary>
    /// PluginLink is object containing pointers to important Miranda
    /// functions.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class PluginLink
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl,
            CharSet=CharSet.Ansi)]
        public delegate IntPtr CreateHookableEventDelegate(string charPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int DestroyHookableEventDelegate(IntPtr handle);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int NotifyEventHooksDelegate(IntPtr handle,
            IntPtr hParam, IntPtr wParam);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl,
            CharSet = CharSet.Ansi)]
        public delegate IntPtr HookEventDelegate(string charPtr,
            [MarshalAs(UnmanagedType.FunctionPtr)] MirandaHook hook);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int UnhookEventDelegate(IntPtr hHook);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl,
            CharSet=CharSet.Ansi)]
        public delegate IntPtr CreateServiceFunctionDelegate(string charPtr,
            [MarshalAs(UnmanagedType.FunctionPtr)] MirandaService fPtr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl,
            CharSet = CharSet.Ansi)]
        public delegate IntPtr CallServiceDelegate(string service,
            IntPtr wParam, IntPtr lParam);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl,
            CharSet = CharSet.Ansi)]
        public delegate IntPtr CallContactServiceDelegate(IntPtr hContact, 
            string charPtr, IntPtr wParam, IntPtr lParam);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate void UnspecifiedDelegate();
        // TODO: Remove this from final version.

        [MarshalAs(UnmanagedType.FunctionPtr)]
        CreateHookableEventDelegate CreateHookableEvent;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        DestroyHookableEventDelegate DestroyHookableEvent;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        NotifyEventHooksDelegate NotifyEventHooks;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public HookEventDelegate HookEvent;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate HookEventMessage;        

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public UnhookEventDelegate UnhookEvent;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public CreateServiceFunctionDelegate CreateServiceFunction;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate CreateTransientServiceFunction;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate DestroyServiceFunction;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public CallServiceDelegate CallService;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate ServiceExists;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate CallServiceSync;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate CallFunctionAsync;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate SetHookDefaultForHookableEvent;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate CreateServiceFunctionParam;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate NotifyEventHooksDirect;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate CallProtoService;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public CallContactServiceDelegate CallContactService;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate HookEventParam;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate HookEventObj;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate HookEventObjParam;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate CreateServiceFunctionObj;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate CreateServiceFunctionObjParam;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate KillObjectServices;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        UnspecifiedDelegate KillObjectEventHooks;
    }
}
