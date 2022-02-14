using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class TopicsController : ControllerBase
{
    private readonly PssContext _context;

    public TopicsController(PssContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult GetTopics()
    {
        return Ok(_context.Topics.ToList());
    }

    [HttpPost]
    public IActionResult AddTopic(Topic topic)
    {
        _context.Add(topic);
        _context.SaveChanges();
        return Ok();
    }
    
    [HttpGet("{topicId}/puntossensibles")]
    public IActionResult GetPoint(string topicId)
    {
        var topic = _context.Topics
            .Include(x => x.Points)
            .FirstOrDefault(x => x.Name == topicId);

        if (topic is null) return NotFound();
        return Ok(topic.Points);
    }

    [HttpPost("{topicId}/puntossensibles")]
    public IActionResult AddPoint(string topicId, SensiblePoint point)
    {
        var topic = _context.Topics
            .Include(x => x.Points)
            .FirstOrDefault(x => x.Name == topicId);
        
        if (topic is null) return NotFound();
        
        topic.Points.Add(point);
        _context.SaveChanges();
        
        return Ok();
    }
}

public class Topic
{
    [Key]
    public string Name { get; init; }
    public DateTime CreatedOn { get; private set; } = DateTime.Now;
    public List<SensiblePoint> Points { get; set; } = new List<SensiblePoint>();
}

public class SensiblePoint
{
    [Key]
    public string Name { get; init; }
    public DateTime CreatedOn { get; private set; } = DateTime.Now;
}