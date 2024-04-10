using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TheWorkshop.Models;

public abstract class Item
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int ScrapValue { get; set; } = 0; // its a surprise tool that will help us later

}

public class CalendarEvent : Item
{
    public DateTime StartTime { get; set; }
    public string? Location { get; set; }
}

public class ToDoTask : Item
{
    public bool IsCompleted { get; set; }
}

public class Deadline : Item
{
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }
}
