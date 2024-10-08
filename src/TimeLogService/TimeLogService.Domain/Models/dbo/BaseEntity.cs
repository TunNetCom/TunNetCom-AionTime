﻿namespace TimeLogService.Domain.Models.Dbo;

public abstract partial class BaseEntity : IRequest<int>
{
    [Key]
    public int Id { get; set; }
}