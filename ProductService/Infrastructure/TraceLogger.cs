﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace ProductService.Infrastructure
{
    public class TraceLogger : ExceptionLogger
    {
        private readonly TraceSource _traceSource;

        public TraceLogger(TraceSource traceSource)
        {
            _traceSource = traceSource;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _traceSource.TraceEvent(TraceEventType.Error, 1,
                "Unhandled exception processing {0} for {1}: {2}",
                context.Request.Method,
                context.Request.RequestUri,
                context.Exception);
        }
    }
}