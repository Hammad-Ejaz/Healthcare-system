using HealthCare.Data.Entity;
using HealthCare.Repository;
using HealthCare.Repository.IRepository;
using HealthCare.Repository.Repository;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.Service.Service
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        private List<string> checkData = new List<string>();
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public List<PrescriptionViewModel> Get1()
        {
            return null;
          //  return _employeeRepository.Get();
        }
        public List<HealthCareChat> Get()
        {
             return _employeeRepository.Get();
        }

        public List<MessageList> GetMessageListByEmpId(string empId, string currentChatEmpId, bool isUnseenMsgs)
        {
            var emp = int.Parse(empId);
            var Message = Get();
                var messagesList = new List<MessageList>();
                var ListOfChatEmp = new List<int?>();
                if (!isUnseenMsgs)
                {
                    ListOfChatEmp = Message.Where(x => x.FromEmpId == emp && (x.IsDeleteByFromEmp == null || !(bool)x.IsDeleteByFromEmp)).Select(x => x.ToEmpId).Distinct().ToList();
                }
                var fetchAllReceivedEmp = Message.Where(x => x.ToEmpId == emp && (x.IsDeleteByToEmp == null || !(bool)x.IsDeleteByToEmp) && !ListOfChatEmp.Contains(x.FromEmpId) && (!isUnseenMsgs || x.IsSeen == null || (bool)x.IsSeen == false)).Select(x => x.FromEmpId).Distinct().ToList();
                for (int i = 0; i < fetchAllReceivedEmp.Count; i++)
                {
                    ListOfChatEmp.Add(fetchAllReceivedEmp[i]);
                }
                for (int i = 0; i < ListOfChatEmp.Count; i++)
                {
                    MessageList obj = new MessageList();
                obj.ChatEmpId = ListOfChatEmp[i] ?? 0;
                 //   var employee = employeeService.GetEmployeeByEmpId(ListOfChatEmp[i]);
                obj.ChatEmpName = "Hammad";
                // employee.LastName + ", " + employee.FirstName;
                obj.ProfileWords = "test";
               // employee.LastName[0].ToString() + employee.FirstName[0].ToString();
                    var messageRecord = Message.Where(x => (!isUnseenMsgs || x.IsSeen == null || (bool)x.IsSeen == false) && x.ToEmpId == emp && x.FromEmpId == ListOfChatEmp[i] && (x.IsDeleteByToEmp == null || !(bool)x.IsDeleteByToEmp) || (!isUnseenMsgs && x.FromEmpId == emp && x.ToEmpId == ListOfChatEmp[i] && (x.IsDeleteByFromEmp == null || !(bool)x.IsDeleteByFromEmp))).OrderBy(x => x.EnteredDate).ToList();
                    obj.NotSeenMsgCount = 0;
                    obj.EmployeeStatusBubble = "blue";
                // employeeService.GetEmployeeStatusBubbleColor(obj.ChatEmpId);
                obj.EmployeeStatus = "Active";
               // employeeService.GetEmployeeStatus(obj.EmployeeStatusBubble);
                    for (int j = 0; j < messageRecord.Count; j++)
                    {
                        InboxMessages msg = new InboxMessages();
                        msg.Id = messageRecord[j].Id;
                        msg.ToEmpId = messageRecord[j].ToEmpId??0;
                        msg.FromEmpId = messageRecord[j].FromEmpId??0;
                        msg.EnteredDate = messageRecord[j].EnteredDate;
                        msg.StringEnteredDate = messageRecord[j].EnteredDate.Value.ToString("h:m tt M/d");
                        msg.Message = messageRecord[j].Message;
                        msg.ImageFile = messageRecord[j].ImageFile;
                        msg.DocumentFile = messageRecord[j].DocumentFile;
                    //      var fromEmp = employeeService.GetEmployeeByEmpId(msg.FromEmpId);
                    msg.FromEmpName = "AHAD";
                    //                        fromEmp.LastName + ", " + fromEmp.FirstName;
                    msg.ToEmpName = "HAMMAD";
                   // employeeService.GetEmployeeNameByEmpId(msg.ToEmpId);
                        msg.IsSeen = messageRecord[j].IsSeen == null || (bool)messageRecord[j].IsSeen == false ? false : true;
                    msg.NameAndEnteredDate = "2021-10-10, HAMMAD";
                   // fromEmp.FirstName + ", " + msg.StringEnteredDate;
                        if (messageRecord[j].IsSeen == true)
                        {
                            msg.StringSeenDate = messageRecord[j].SeenDate != null ? "READ : " + messageRecord[j].SeenDate.Value.ToString("h:m tt M/d") : "";
                        }
                        else
                        {
                            msg.StringSeenDate = "UNREAD";
                        }
                        if (msg.ToEmpId == emp)
                        {
                            msg.Color = "#f2f6f9 !important";
                        }
                        else
                        {
                            msg.Color = "#dbf1ff !important";
                        }
                        obj.MessagesRecord.Add(msg);
                        if ((messageRecord[j].IsSeen == null || (bool)messageRecord[j].IsSeen == false) && messageRecord[j].ToEmpId == emp)
                        {
                            obj.NotSeenMsgCount = obj.NotSeenMsgCount + 1;
                        }
                    }
                    obj.LastEnteredDate = messageRecord[messageRecord.Count - 1].EnteredDate;
                    obj.StringLastEnteredDate = messageRecord[messageRecord.Count - 1].EnteredDate.Value.ToString("h:m tt M/d");
                    obj.LastMessage = messageRecord[messageRecord.Count - 1].Message;
                    if (!String.IsNullOrEmpty(messageRecord[messageRecord.Count - 1].ImageFile))
                    {
                        obj.ImagePresent = true;
                    }
                    if (!String.IsNullOrEmpty(messageRecord[messageRecord.Count - 1].DocumentFile))
                    {
                        obj.DocumentName = Path.GetFileName(messageRecord[messageRecord.Count - 1].DocumentFile);
                    }
                    if (currentChatEmpId == obj.ChatEmpId.ToString())
                    {
                        obj.CurrentChatBgColor = "#dbf1ff";
                    }
                    else
                    {
                        obj.CurrentChatBgColor = "transparent";
                    }
                    messagesList.Add(obj);
                }
                return messagesList.OrderByDescending(x => x.LastEnteredDate).ToList();
        }


        public async Task AddDataToList (string data)
        {
            checkData.Add(data);
        }
        public async Task<List<string>> GetDataList()
        {
            return checkData;
        }
        public List<ExceptionLog> GetList()
        {
            return _employeeRepository.GetList();
                 
            //List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            //foreach(var obj in _employeeRepository.GetList())
            //{
            //    EmployeeViewModel _obj = new EmployeeViewModel();
            //    _obj.FirstName = obj.FirstName;
            //    _obj.LastName = obj.LastName;
            //    _obj.Address =  obj.Address;
            //    employees.Add(_obj);
            //}
            //return employees;
        }
    }
}
