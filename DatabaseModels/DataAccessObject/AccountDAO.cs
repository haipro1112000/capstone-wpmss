using DatabaseWPMSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels.DataAccessObject
{
    public class AccountDAO
    {
        MyDatabase mydb = new MyDatabase();

        //bước 1: truy vấn về SQL server để lấy database.
        // function Login
        public ACCOUNT GetObjectUserByUserName(string username)
        {
            return mydb.ACCOUNT.Where(a => a.Username == username).FirstOrDefault();
            //FirstOrDefault : trả về một giá trị mặc định khác null
        }

        // LẤY TOÀN BỘ DANH SÁCH TRONG BẢNG
        // HÀM  NÀY HỖ TRỢ CHO VIỆC ĐẨY DỮ LIỆU LÊN BẢNG
        public List<ACCOUNT> getAcc()
        {
            return mydb.ACCOUNT.ToList();
        }
        // Hỗ trợ add account
        // Lấy ra tất cả username trong bảng để check trường hợp có trùng username hay ko
        public List<ModelView.Acc_Username> GetUsername()
        {
            var query = from a in mydb.ACCOUNT

                        select new ModelView.Acc_Username()
                        {
                            Acc_ID = a.Acc_ID,
                            Username = a.Username,
                        };
            return query.ToList();
        }


        // HÀM NÀY ĐỂ THÊM MỘT ĐỐI TƯỢNG MỚI
        // Add Account
        public void AddObject<T>(T obj)
        {
            mydb.Set(obj.GetType()).Add(obj);
        }

        //  LẤY MỘT ACCOUNT KHI BIẾT ACCID
        // Hàm Update account
        public ACCOUNT GetAccByAccID(int id)
        {
            return mydb.ACCOUNT.Where(a => a.Acc_ID == id).FirstOrDefault();
        }

        // HÀM DELETE 1 ACCOUNT
        public void DeleteObject<T>(T obj)
        {
            mydb.Set(obj.GetType()).Remove(obj);
        }

        // HÀM NÀY ĐỂ LƯU MỌI THAY ĐỔI
        public void Save()
        {
            mydb.SaveChanges();
        }
    }
}
