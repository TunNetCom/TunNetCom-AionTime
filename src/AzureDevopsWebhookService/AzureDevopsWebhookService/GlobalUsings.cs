﻿global using MassTransit;
global using MediatR;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Newtonsoft.Json;
global using OpenTelemetry.Instrumentation.AspNetCore;
global using OpenTelemetry.Logs;
global using OpenTelemetry.Metrics;
global using OpenTelemetry.Resources;
global using OpenTelemetry.Trace;
global using Serilog;
global using Serilog.Events;
global using Serilog.Sinks.Grafana.Loki;
global using System.Net;
global using System.Runtime.InteropServices;
global using System.Threading.Channels;