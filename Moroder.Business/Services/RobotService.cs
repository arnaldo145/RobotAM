using Kraftwerk.ValueObjects.Arm;
using Kraftwerk.ValueObjects.Head;
using Kraftwerk.ValueObjects.Robot;
using Kraftwerk.ValueObjects.RobotResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Moroder.Business.Services
{
    public class RobotService : IRobotService
    {
        private readonly string _kraftwerkAPIUrl = "http://localhost:44386";

        public RobotVO GetRobot(long id)
        {
            RobotVO robot = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_kraftwerkAPIUrl);

                Task<HttpResponseMessage> responseTask = client.GetAsync($"api/robot/{id}");
                responseTask.Wait();

                HttpResponseMessage result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    Task<RobotVO> readTask = result.Content.ReadAsAsync<RobotVO>();
                    readTask.Wait();
                    robot = readTask.Result;
                }
            }

            return robot;
        }

        public IEnumerable<RobotVO> GetRobots()
        {
            IEnumerable<RobotVO> robots = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_kraftwerkAPIUrl);

                Task<HttpResponseMessage> responseTask = client.GetAsync("api/robot");
                responseTask.Wait();

                HttpResponseMessage result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<IList<RobotVO>> readTask = result.Content.ReadAsAsync<IList<RobotVO>>();
                    readTask.Wait();
                    robots = readTask.Result;
                }
                else  
                {
                    robots = Enumerable.Empty<RobotVO>();
                }

                return robots;
            }
        }

        public long PostRobot()
        {
            RobotResult robotResult = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_kraftwerkAPIUrl);

                Task<HttpResponseMessage> postTask = client.PostAsync("api/robot", null);
                postTask.Wait();

                HttpResponseMessage result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<RobotResult> readTask = result.Content.ReadAsAsync<RobotResult>();
                    readTask.Wait();
                    robotResult = readTask.Result;
                }
            }

            return robotResult.Id;
        }

        public bool DeleteRobot(long id)
        {
            bool isRobotDeleted = false; 

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_kraftwerkAPIUrl);

                Task<HttpResponseMessage> deleteTask = client.DeleteAsync($"api/Robot/{id}");
                deleteTask.Wait();

                HttpResponseMessage result = deleteTask.Result;
                isRobotDeleted = result.IsSuccessStatusCode;
            }

            return isRobotDeleted;
        }

        public bool PutHead(long id, HeadVO headMoved)
        {
            bool isHeadMoved = false;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_kraftwerkAPIUrl);

                Task<HttpResponseMessage> putTask = client.PutAsJsonAsync<HeadVO>($"api/Robot/{id}/Head", headMoved);
                putTask.Wait();

                HttpResponseMessage result = putTask.Result;

                if (result.IsSuccessStatusCode)
                    isHeadMoved = true;
                else if (result.StatusCode == HttpStatusCode.BadRequest)
                    isHeadMoved = false;
            }

            return isHeadMoved;
        }

        public bool PutLeftArm(long id, ArmVO leftArmMoved)
        {
            bool isLeftArmMoved = false;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_kraftwerkAPIUrl);

                var putTask = client.PutAsJsonAsync<ArmVO>($"api/Robot/{id}/LeftArm", leftArmMoved);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                    isLeftArmMoved = true;
                else if (result.StatusCode == HttpStatusCode.BadRequest)
                    isLeftArmMoved = false;
            }

            return isLeftArmMoved;
        }

        public bool PutRightArm(long id, ArmVO rightArmMoved)
        {
            bool isRightArmMoved = false;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_kraftwerkAPIUrl);

                var putTask = client.PutAsJsonAsync<ArmVO>($"api/Robot/{id}/LeftArm", rightArmMoved);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                    isRightArmMoved = true;
                else if (result.StatusCode == HttpStatusCode.BadRequest)
                    isRightArmMoved = false;
            }

            return isRightArmMoved;
        }

        public HeadVO GetHead(long id)
        {
            HeadVO head = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_kraftwerkAPIUrl);

                Task<HttpResponseMessage> responseTask = client.GetAsync($"api/robot/{id}/Head");
                responseTask.Wait();

                HttpResponseMessage result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    Task<HeadVO> readTask = result.Content.ReadAsAsync<HeadVO>();
                    readTask.Wait();
                    head = readTask.Result;
                }
            }

            return head;
        }

        public ArmVO GetLeftArm(long id)
        {
            ArmVO leftArm = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_kraftwerkAPIUrl);

                Task<HttpResponseMessage> responseTask = client.GetAsync($"api/robot/{id}/LeftArm");
                responseTask.Wait();

                HttpResponseMessage result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    Task<ArmVO> readTask = result.Content.ReadAsAsync<ArmVO>();
                    readTask.Wait();
                    leftArm = readTask.Result;
                }
            }

            return leftArm;
        }

        public ArmVO GetRightArm(long id)
        {
            ArmVO rightArm = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_kraftwerkAPIUrl);

                Task<HttpResponseMessage> responseTask = client.GetAsync($"api/robot/{id}/RightArm");
                responseTask.Wait();

                HttpResponseMessage result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    Task<ArmVO> readTask = result.Content.ReadAsAsync<ArmVO>();
                    readTask.Wait();
                    rightArm = readTask.Result;
                }
            }

            return rightArm;
        }
    }
}
