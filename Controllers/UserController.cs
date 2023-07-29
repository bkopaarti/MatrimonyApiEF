using System.Data;
using System.Net.Http.Headers;
using MatrimonyApiEF.Models;
using MatrimonyApiEF.Models.dssfunctions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MatrimonyApiEF.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private MatrimonyContext _context;

        private ResultFormat _result = new ResultFormat();

        private const string baseUrl = "/api/user";

        private readonly IOptions<UserSettings> Settings;

        public UserController(
            MatrimonyContext context,
            IOptions<UserSettings> op
        )
        {
            _context = context;
            Settings = op;
        }

        [HttpGet]
        [Route(baseUrl + "/getRegisteredUsers")]
        public async Task<ActionResult> GetRegisterdUsers(int userId)
        {
            try
            {
                _result.data =
                    await _context
                        .BasicInfos
                        .Where(w => w.UserId != userId)
                        .Select(s =>
                            new {
                                s.UserId,
                                s.Name,
                                s.Email,
                                s.Phone,
                                s.Address,
                                s.City,
                                s.Gender,
                                s.Pincode
                            })
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                _result.status_cd = 0;
                _result.errors.exception = ex.Message;
            }
            return Ok(_result);
        }

        [HttpGet]
        [Route(baseUrl + "/getIsUserRegistered")]
        public async Task<ActionResult>
        IsUserRegistered(string phoneNo, string password)
        {
            try
            {
                _result.data =
                    await _context
                        .BasicInfos
                        .Where(u =>
                            u.Phone == phoneNo && u.Password == password)
                        .Select(s => new { s.UserId })
                        .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _result.status_cd = 0;
                _result.errors.exception = ex.Message;
            }
            return Ok(_result);
        }

        [HttpGet]
        [Route(baseUrl + "/getAllInfo")]
        public async Task<ActionResult> GetUserAllInfo(int userId)
        {
            try
            {
                _result.data =
                    await _context
                        .BasicInfos
                        .Where(w => w.UserId == userId)
                        .Select(s =>
                            new {
                                s.UserId,
                                basicDetail =
                                    new {
                                        s.UserId,
                                        s.Phone,
                                        s.Address,
                                        s.Email,
                                        s.City,
                                        s.Pincode,
                                        s.Name,
                                        s.Gender
                                    },
                                s.PersonalDetail,
                                s.EducationalDetail,
                                s.FamilyDetail
                            })
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                _result.status_cd = 0;
                _result.errors.exception = ex.Message;
            }
            return Ok(_result);
        }

        [HttpPost]
        [Route(baseUrl + "/addBasicInfo")]
        public async Task<ActionResult> AddBasicInfo([FromBody] BasicInfo data)
        {
            try
            {
                _context.BasicInfos.Add (data);
                await _context.SaveChangesAsync();
                _result.data = new { data.UserId };
            }
            catch (Exception e)
            {
                _result.status_cd = 0;
                _result.errors.exception = e.Message;
            }
            return Ok(_result);
        }

        [HttpPost]
        [Route(baseUrl + "/addPersonalInfo")]
        public async Task<ActionResult>
        AddPersonalInfo([FromBody] PersonalDetail data)
        {
            try
            {
                _context.PersonalDetails.Add (data);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _result.status_cd = 0;
                _result.errors.exception = e.Message;
            }
            return Ok(_result);
        }

        [HttpPost]
        [Route(baseUrl + "/addFamilyInfo")]
        public async Task<ActionResult>
        AddFamilyInfo([FromBody] FamilyDetail data)
        {
            try
            {
                _context.FamilyDetails.Add (data);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _result.status_cd = 0;
                _result.errors.exception = e.Message;
            }
            return Ok(_result);
        }

        [HttpPost]
        [Route(baseUrl + "/addEducationalInfo")]
        public async Task<ActionResult>
        AddEducationalInfo([FromBody] EducationalDetail data)
        {
            try
            {
                _context.EducationalDetails.Add (data);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _result.status_cd = 0;
                _result.errors.exception = e.Message;
            }
            return Ok(_result);
        }

        [HttpPost]
        [Route(baseUrl + "/addParnertInfo")]
        public async Task<ActionResult>
        AddParnertDetails([FromBody] ParnterPreferenceDetail data)
        {
            try
            {
                _context.ParnterPreferenceDetails.Add (data);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _result.status_cd = 0;
                _result.errors.exception = e.Message;
            }
            return Ok(_result);
        }

        [HttpPost]
        [Route(baseUrl + "/addPicture")]
        public async Task<ActionResult> Upload(int userId, string typ)
        {
            try
            {
                string root = Settings.Value.uploadfile.path;

                if (userId != 0) root = root + "\\" + userId;

                if (!Directory.Exists(root)) Directory.CreateDirectory(root);

                string folder = root + "\\" + typ;
                bool folderExists = Directory.Exists(folder);

                if (!folderExists) Directory.CreateDirectory(folder);

                var formCollection = await Request.ReadFormAsync();

                foreach (var file in formCollection.Files)
                {
                    if (file.Length > 0)
                    {
                        string guid = Guid.NewGuid().ToString();
                        var ext =
                            ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Split('.');

                        var filename =
                            guid + "." + ext[ext.Length - 1].Replace("\"", "");
                        var fullPath = Path.Combine(folder, filename);

                        using (
                            var stream =
                                new FileStream(fullPath, FileMode.Create)
                        )
                        {
                            file.CopyTo (stream);
                        }

                        if (!updateVoucher(typ, typ + "\\" + filename, userId))
                        {
                            if ((System.IO.File.Exists(fullPath)))
                            {
                                System.IO.File.Delete (fullPath);
                            }

                            break;
                        }
                    }
                }
                _result.data = "File Uploaded";
            }
            catch (Exception ex)
            {
                _result.status_cd = 0;
                _result.errors.message = ex.Message;
            }
            return Ok(_result);
        }

        private bool updateVoucher(string typ, string filename, int userId)
        {
            try
            {
                _context
                    .UserPictures
                    .Add(new UserPicture {
                        UserId = userId,
                        Filepath = filename,
                        Type = typ
                    });

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _result.status_cd = 0;
                _result.errors.message = ex.Message;
                return false;
            }
        }
    }
}
