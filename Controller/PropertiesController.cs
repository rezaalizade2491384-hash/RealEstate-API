using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.DTOs;
using RealEstate.Api.Services;

namespace RealEstate.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]  // ← همه متدها نیاز به احراز هویت دارند
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _service;

        public PropertiesController(IPropertyService service)
        {
            _service = service;
        }

        // GET: همه ملک‌ها (همه می‌توانند ببینند)
        [HttpGet]
        [AllowAnonymous]  // ← بدون نیاز به توکن
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // GET: یک ملک با ID (همه می‌توانند ببینند)
        [HttpGet("{id}")]
        [AllowAnonymous]  // ← بدون نیاز به توکن
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound(new { message = "ملک مورد نظر یافت نشد" });

            return Ok(result);
        }

        // POST: ساخت ملک جدید (فقط کاربران لاگین‌شده)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePropertyDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: ویرایش کامل ملک (فقط کاربران لاگین‌شده)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePropertyDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.UpdateAsync(id, updateDto);

            if (result == null)
                return NotFound(new { message = "ملک مورد نظر یافت نشد" });

            return Ok(result);
        }

        // DELETE: حذف ملک (فقط کاربران لاگین‌شده)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);

            if (!success)
                return NotFound(new { message = "ملک مورد نظر یافت نشد" });

            return Ok(new { message = "ملک با موفقیت حذف شد" });
        }
    }
}