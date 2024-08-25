﻿global using MediatR;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Mvc;
global using Newtonsoft.Json;
global using OpenTelemetry.Instrumentation.AspNetCore;
global using OpenTelemetry.Logs;
global using OpenTelemetry.Metrics;
global using OpenTelemetry.Resources;
global using OpenTelemetry.Trace;
global using Serilog;
global using Serilog.Events;
global using System.Net;
global using TunNetCom.AionTime.TimeLogService.API;
global using TunNetCom.AionTime.TimeLogService.API.Middelware;
global using TunNetCom.AionTime.TimeLogService.Application;
global using TunNetCom.AionTime.TimeLogService.Contracts.DTOs.Request;
global using TunNetCom.AionTime.TimeLogService.Infrastructure;
global using TunNetCom.AionTime.TimeLogService.Infrastructure.AionTimeContext;