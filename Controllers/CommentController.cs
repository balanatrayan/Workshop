using ChatGPTModeration.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChatGPTModeration.Controllers
{
    public class CommentController : Controller
    {
        private IChatGPTService _chatGPTService;
        private CommentsContext context { get; set; }

        public CommentController(CommentsContext context, IChatGPTService chatGPTService)
        {
            this.context = context;
            this._chatGPTService = chatGPTService;
        }

        public IActionResult Index()
        {
            ViewBag.Comments = context.Comments.ToList();   
            return View();
        }

        public IActionResult Create()
        {
            return View("Add");
        }

        public IActionResult Details(Guid commentId)
        {
            var comment = context.Comments.Find(commentId);
            if(comment.ChatGPTResults != null)
            {
                ViewBag.result = JsonConvert.DeserializeObject(comment.ChatGPTResults);
            }               
            
            return View(comment);
        }

        public IActionResult Delete(Guid commentId)
        {
            var comment = context.Comments.Find(commentId);
            context.Comments.Remove(comment);
            context.SaveChanges();

            ViewBag.Comments = context.Comments.ToList();
            return View("Index");
        }

        public async Task<IActionResult> Add(CommentModel model)
        {
            ModerationResponse gptResponse = await _chatGPTService.ExecutePrompt(new ModerationRequest { input = model.Comment});

            var approved = gptResponse?.results?.All(x => x.flagged == false);
            model.Approved = approved == true;
            model.CommnetId = Guid.NewGuid();
            model.ChatGPTResults = JsonConvert.SerializeObject(gptResponse.results);           

            context.Add(model);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult All()
        {
            return View();
        }
    }
}
