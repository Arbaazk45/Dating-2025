using System;

namespace API.DTOs;

public class MessageDto
{
    public required string Id { get; set; }

    public required string SenderId { get; set; }
    public required string SenderDisplayName { get; set; }

    public string? SenderImageUrl { get; set; }

    public required string RecieverId { get; set; }
    public required string RecieverDisplayName { get; set; }

    public string? RecieverImageUrl { get; set; }
    public required string Content { get; set; }

    public DateTime MessageSent { get; set; } = DateTime.UtcNow;
    public DateTime DateRead { get; set; }
}
