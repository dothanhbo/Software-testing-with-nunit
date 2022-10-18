﻿using BusinessObject;
using DataAccess;
using DataAccess.Repository;
using NUnit.Framework;


namespace NUnitTest
{
    public class MemberDAOUnitTest
    {
        //Để chạy test: chọn Test trên thanh taskbar, chọn run test
        // phím tắt chạy test: Ctrl R A
        MemberRepository memberRepository;


        // hàm nạy chạy đầu tiên khi vào test
        [SetUp]
        public void Setup()
        {
            memberRepository = new MemberRepository();
        }

        /*
        // một Test case cơ bản
        [Test]
        public void TestDemo()
        {
            // so sánh 2 giá trị cơ bản
            Assert.AreEqual(1, 1);

        }

        // TestCase với parameter truyền vào -> thử được nhiều data cũng lúc | Method cũng phải có parameter | số lượng parameter trên dưới phải giống nhau
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        public void TestCaseDemo(int a, int b)
        {
            // so sánh 2 giá trị 
            Assert.AreEqual(a, b);
        }

        // TestCase với parameter truyền vào đi kèm Expected luôn -> thử được nhiều data cùng lúc | Method cũng phải return giá trị
        // không cần Assert
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 2)]

        public int TestCaseWithExeptedDemo(int a)
        {
            return a;
        }

        // Test xem có quăng lỗi ra không
        [Test]
        public void ExpectionDemo()
        {
            // thay method quăng lỗi thành method tương ứng
            // Assert.Throws<System.Exception>(() => MethodQuangLoi());
        }


        // Cơ bản nhiêu đó thôi. Viết code test từng method trong MemberDAO đi anh em =))
        // Tham khảo thêm tại https://docs.nunit.org/articles/nunit/writing-tests/attributes.html
        */
        // Vô code:
        // TEST METHOD GetDefaultMember()
        [Test]
        public void LoginUnitTest()
        {
            // Trả về Tài khoảng trong file // appsettings
            // user "email": "admin@fstore.com",
            // "password": "admin@@"
            // Tra ve tai khoan admin nay neu dung
            var actual = memberRepository.Login("admin@fstore.com", "admin@@");
            var expected = new MemberObject{
                MemberID = 1,
                Email = "admin@fstore.com",
                Password = "admin@@",
                City = "",
                Country = "",
                MemberName = "Admin"
            };
            Assert.IsTrue(CompareTwoMemberObject(expected,actual));
            
            // sai tra ve null
            actual = memberRepository.Login("admin@fstore.com", "Ahihi");
            Assert.IsTrue(actual == null);
            

        }


        public bool CompareTwoMemberObject(MemberObject A, MemberObject B)
        {
            
            if (A.MemberID != B.MemberID) return false;
            if (A.Email != B.Email) return false;
            if (A.Password != B.Password) return false;
            if (A.Country != B.Country) return false;
            if (A.City != B.City) return false;
            if (A.MemberName != B.MemberName) return false;
            return true;
            

        }
    }
}