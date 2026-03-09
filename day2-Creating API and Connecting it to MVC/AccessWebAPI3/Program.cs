
using Microsoft.Graph.Models;
using System.Net.Http.Json;


// API Call to WebAPI 3
using (var client = new HttpClient())
{
    client.BaseAddress = new Uri("https://localhost:7033/api/Students");

    var students = await client.GetFromJsonAsync<List<Student>>("Students");

    if (students != null)
    {
        foreach (var user in students)
        {
            Console.WriteLine($"{user.StudentId} - {user.FullName} - {user.Email} - {user.Phone}");
        }
    }
}


public class Student
{
    public int StudentId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly JoinDate { get; set; }

    public DateTime CreatedAt { get; set; }

}