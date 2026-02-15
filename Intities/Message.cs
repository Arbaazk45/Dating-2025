using System;

namespace API.Intities;

public class Message
{
     public string Id { get; set; } = null!;
    public required string Content { get; set; }

    public DateTime MessageSent { get; set; }
    public DateTime? DateRead { get; set; }

    public bool Senderdeleted { get; set; }
    public bool Recipientdeleted { get; set; }

    //    navigation property
    public required string SenderId { get; set; }

    public Members Sender { get; set; } = null!;

    public required string RecieverId { get; set; }
    public Members Reciever { get; set; } = null!;

}
