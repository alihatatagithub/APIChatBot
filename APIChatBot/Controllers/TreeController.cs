using APIChatBot.Data;
using APIChatBot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIChatBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TreeController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<TreeController>
        [HttpGet]
        public IEnumerable<Tree> Get()
        {
            return _context.Tree;
        }

        [HttpGet("GetParents")]
        public IEnumerable<Tree> GetParents()
        {
            return _context.Tree.Where(a => a.ParentId == null);
        }

        [HttpGet("GetChildrenByParentId")]
        public IEnumerable<Tree> GetChildrenByParentId(int id)
        {
            return _context.Tree.Where(a => a.ParentId == id);
        }

        [HttpGet("HaveChildren")]
        public bool HaveChildren(int id)
        {
            return _context.Tree.Any(a => a.ParentId == id);
        }

        // GET api/<TreeController>/5
        [HttpGet("{id}")]
        public Tree Get(int id)
        {
            var tree = _context.Tree.FirstOrDefault(a => a.Id == id);

            return tree;
        }

        // POST api/<TreeController>
        [HttpPost]
        public void Post([FromBody] Tree model)
        {
            _context.Tree.Add(model);
            _context.SaveChanges();
        }

        // PUT api/<TreeController>/5
        [HttpPut("{id}")]
        public void Put( [FromBody] Tree model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // DELETE api/<TreeController>/5
   
    }
}
