using ReliableKafkaProducer.Models;

namespace ReliableKafkaProducer.Messages;

public struct KafkaMessage
{
    public string Key;
    public int Partition;
    public LeaveApplicationReceived Message;
};