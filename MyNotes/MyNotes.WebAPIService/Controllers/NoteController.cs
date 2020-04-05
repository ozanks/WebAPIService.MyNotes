using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNotes.Business.Abstract;
using MyNotes.Entities;
using MyNotes.WebAPIService.Filters;
using MyNotes.WebAPIService.Models;

namespace MyNotes.WebAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService noteService;

        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        [HttpGet]
        [NoteException]
        public IActionResult Get()
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>
            {
                Entities = noteService.GetAll(),
                IsSuccesful = true
            };
            response.EntitiesCount = response.Entities.Count();
            return Ok(response);
        }
        [HttpGet("{id}")]
        [NoteException]
        public IActionResult Get(int id)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>
            {
                Entity = noteService.GetById(id),
                IsSuccesful = true
            };
            return Ok(response);
        }
        [HttpPost]
        [NoteException]
        [NoteValidate]
        public IActionResult Post([FromBody] NoteModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    return BadRequest(model);
            //}
            Note note = new Note
            {
                NoteTitle = model.NoteTitle,
                NoteDescription = model.NoteDescription,
                CategoryId = model.CategoryId
            };
            noteService.Add(note);

            ServiceResponse<Note> response = new ServiceResponse<Note>
            {
                Entity = note,
                IsSuccesful = true
            };

            return Ok();
        }

        [HttpPut]
        [NoteException]
        [NoteValidate]
        public IActionResult Put(int id, [FromBody] NoteModel model)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>();
            var note = noteService.GetById(id);
            if (note == null)
            {
                response.HasErrors = true;
                response.Errors.Add("Not bulunamadı!");
                return BadRequest(response);
            }
            note.NoteTitle = model.NoteTitle;
            note.NoteDescription = model.NoteDescription;
            note.CategoryId = model.CategoryId;

            noteService.Update(note);
            response.IsSuccesful = true;
            return Ok(response);
        }

        [HttpDelete]
        [NoteException]
        public IActionResult Delete(int id)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>();
            var note = noteService.GetById(id);
            if (note == null)
            {
                response.HasErrors = true;
                response.Errors.Add("Not bulunamadı!");
                return BadRequest(response);
            }
            noteService.Delete(note);
            response.IsSuccesful = true;
            return Ok(response);
        }
    }
}