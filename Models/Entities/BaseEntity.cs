using System;

public class BaseEntity
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public DateTime? CreatedTime { get; set; }
}