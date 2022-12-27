using APIChatBot.Data;
using APIChatBot.DTO;
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
        public IEnumerable<TreeDto> GetChildrenByParentId(int id)
        {
            var trees = _context.Tree.Where(a => a.ParentId == id).ToList();
            var treesDto = new List<TreeDto>();
            foreach (var item in trees)
            {
                TreeDto treeDto = new TreeDto();
                treeDto.Id = item.Id;
                treeDto.Name = item.Name;
                treeDto.ParentId = item.ParentId;
                treeDto.HasChildren = _context.Tree.Any(a => a.ParentId == item.Id) ? true : false;
                treesDto.Add(treeDto);
            }
            return treesDto;    
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
