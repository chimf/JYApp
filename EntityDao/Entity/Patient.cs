using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntityDao.Entity
{
    public class Patient
    {
        private string _userName;
        private string _userCardNo;
        private string _userCardType;
        private int _userAge;
        private string _userSex;
        private string _userBarcode;
        private string _userCollectTime;
        private string _userCollecter;
        private string _userPhone;
        private string _userCommand;
        private string _userCollectType;
        private string _userSendUnit;
        private string _userUnit;
        private string _userJob;
        private string _userSubJob;
        private string _userSampleType;
        private string _userArea;
        private int _isInput;
        private string _cost;
        private string _userNote;
        private int _isCool;
        private string _email;

        public string UserName { get => _userName; set => _userName = value; }
        public string UserCardNo { get => _userCardNo; set => _userCardNo = value; }
        public string UserCardType { get {
                if (_userCardNo.Length == 15 || _userCardNo.Length == 18)
                {
                    imp.IDCard id = imp.IDCard.Parse(_userCardNo);
                    if (id != null)
                        this._userCardType = "居民身份证";
                }
                else
                if (!imp.IDCard.isHKCard(_userCardNo).Equals(""))
                    this._userCardType = imp.IDCard.isHKCard(_userCardNo);
                else if (!imp.IDCard.isTWCard(_userCardNo).Equals(""))
                    this._userCardType = imp.IDCard.isTWCard(_userCardNo);
                else
                    this._userCardType = imp.IDCard.isPassportCard(_userCardNo);

                return _userCardType;
                
            } set => _userCardType = value; }
        public int UserAge { get {
                imp.IDCard id = imp.IDCard.Parse(_userCardNo);
                if (id != null)
                    this._userAge = id.GetAge();
                return _userAge;
            } set => _userAge = value; }
        public string UserSex { get {

                imp.IDCard id = imp.IDCard.Parse(_userCardNo);
                if (id != null)
                    this._userSex = id.sex.Equals("1") ? "男" : (id.sex.Equals("2") ? "女" : "未知");
                return _userSex;
            } set => _userSex = value; }
        public string UserBarcode { get => _userBarcode; set => _userBarcode = value; }
        public string UserCollectTime { get {
                if (String.IsNullOrEmpty(_userCollectTime))
                {
                    _userCollectTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    return _userCollectTime;
                }
                else
                {
                    DateTime d;
                    if (DateTime.TryParse(_userCollectTime, out d))
                        return d.ToString("yyyy-MM-dd HH:mm:ss");
                    else

                        return _userCollectTime = "";
                }
            } set => _userCollectTime = value; }
        public string UserCollecter { get => _userCollecter; set => _userCollecter = value; }
        public string UserPhone { get => _userPhone; set => _userPhone = value; }
        public string UserCommand { get => _userCommand; set => _userCommand = value; }
        public string UserCollectType { get => _userCollectType; set => _userCollectType = value; }
        public string UserSendUnit { get => _userSendUnit; set => _userSendUnit = value; }
        public string UserUnit { get => _userUnit; set => _userUnit = value; }
        public string UserJob { get {
                string value = _userSendUnit;
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Contains("个人"))
                        this._userJob = "其他人群";
                    else
                    if (value.Contains("学校") || value.Contains("小学") || value.Contains("教育局"))
                    {
                        this._userJob = "学校教职员工_含后勤人员_";
                        this._userSubJob = "中小学";
                    }
                    else
                    if (value.Contains("幼儿园"))
                    {
                        this._userJob = "学校教职员工_含后勤人员_";
                        this._userSubJob = "托幼机构";
                    }
                    else
                    if (value.Contains("医院"))
                    {
                        this._userJob = "住院患者及陪护人员";
                        this._userSubJob = "住院陪护人员";
                    }
                    return _userJob;
                }
                else
                    return _userJob="";
                
            } set => _userJob=value; }
        public string UserSubJob { get {
                if (!string.IsNullOrEmpty(_userUnit))
                {
                    if (_userUnit.Contains("陪护"))
                        _userJob = "住院患者及陪护人员";
                    return _userSubJob;
                }
                else
                    return _userSubJob = "";

            }
            set => _userSubJob = value; }
        public string UserSampleType { get => _userSampleType; set => _userSampleType = value; }
        public string UserArea { get => _userArea; set => _userArea = value; }
        public int IsInput { get => _isInput; set => _isInput = value; }
        public string Cost { get => _cost; set => _cost = value; }
        public string UserNote { get => UserNote1; set => UserNote1 = value; }
        public string UserNote1 { get => _userNote; set => _userNote = value; }
        public int IsCool { get => _isCool; set => _isCool = value; }
        public string Email { get => _email; set => _email = value; }
    }
}
