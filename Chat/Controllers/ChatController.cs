using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBusiness;
using Repository;

namespace Chat.Controllers
{
    [Authorize(Roles = "User")]
    [Authorize(AuthenticationSchemes = "User")]
    public class ChatController : Controller
    {
        #region Variable
        private readonly IMessageRepository messageRepository;
        #endregion

        #region Constructor
        public ChatController()
        {
            messageRepository = new MessageRepository();
        }
        #endregion

        // GET: ChatController
        public ActionResult Index()
        {
            var listMessage = messageRepository.GetMessages();
            return View(listMessage);
        }

        // POST: ChatController/Chat
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Chat(string accountIdSend, string content)
        {
            int accountId = Convert.ToInt32(Request.Cookies["accountId"]);
            try
            {
                Random random = new Random();

                Message message = new Message();
                message.Contents = content;
                message.MessageId = random.Next();
                message.AccountId = accountId;
                message.AccountReceive = Convert.ToInt32(accountIdSend);

                var statusSend = messageRepository.SendMessage(message);
                if (statusSend.Equals("success"))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: ChatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChatController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
