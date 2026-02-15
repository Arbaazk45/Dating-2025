using System;

namespace API.Error;

public class APIError(int statusCode,string message,string? details)
{
 public int statusCode  { get; set; } = statusCode;
 public string messsage { get; set; } = message;

 public string? error { get; set; } =details;
}
