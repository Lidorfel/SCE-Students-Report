using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TDDWorkTests1;

namespace TDDWork.Tests
{
    [TestClass()]
    public class StudentTests
    {

        //Student's average Tests
        [TestMethod()]
        public void get_GPATest1()
        {
            double[] grades = new double[] { 60, 70, 80, 90, 100 };
            var T = new TDDWork.Student("123456789", "Lidor", "Feldman", "lid@gmail.com", "0501122334",grades);
            double averageExpected = 80.0;
            double averageActual = T.get_GPA();
            Assert.AreEqual(averageExpected,averageActual);
        }
        [TestMethod()]
        public void get_GPATest2()
        {
            double[] grades = new double[] { 60, 70, 777, 90, 45 };
            var T = new TDDWork.Student("123456789", "Lidor", "Feldman", "lid@gmail.com", "0501122334", grades);
            double averageExpected = 53.0;
            double averageActual = T.get_GPA();
            Assert.AreEqual(averageExpected, averageActual);
        }
        [TestMethod()]
        public void get_GPATest3()
        {
            double[] grades = new double[] { 40, 90, 777, 777, 65 };
            var T = new TDDWork.Student("123456789", "Lidor", "Feldman", "lid@gmail.com", "0501122334", grades);
            double averageExpected = 349.8;//with sum of 777
            double averageActual = T.get_GPA();
            Assert.AreNotEqual(averageExpected,averageActual);
        }


        //Student's Id tests
        [WpfTestMethod]
        public void checkIdTest1()
        {
            //checkId possible outcomes : (-1) - notValid has non numeric chars
            //0 - valid , 1 - notValid incorrect num of chars(9),
            //2 - notValid id can't start with 0, 3 - empty string
            //success test
            var T = new TDDWork.MainWindow();
            string idTest = "123456789";
            int flag = T.checkId(idTest);
            Assert.AreEqual(0, flag);

        }
        [WpfTestMethod]
        public void checkIdTest2()
        {
            //checkId possible outcomes : (-1) - notValid has non numeric chars
            //0 - valid , 1 - notValid incorrect num of chars(9),
            //2 - notValid id can't start with 0, 3 - empty string
            //fail test
            var T = new TDDWork.MainWindow();
            string idTest = "023456789";
            int flag = T.checkId(idTest);
            Assert.AreEqual(2, flag);

        }
        [WpfTestMethod]
        public void checkIdTest3()
        {
            //checkId possible outcomes : (-1) - notValid has non numeric chars
            //0 - valid , 1 - notValid incorrect num of chars(9),
            //2 - notValid id can't start with 0, 3 - empty string
            //fail test
            var T = new TDDWork.MainWindow();
            string idTest = "12345l$89";
            int flag = T.checkId(idTest);
            Assert.AreEqual(-1, flag);

        }
        [WpfTestMethod]
        public void checkIdTest4()
        {
            //checkId possible outcomes : (-1) - notValid has non numeric chars
            //0 - valid , 1 - notValid incorrect num of chars(9),
            //2 - notValid id can't start with 0, 3 - empty string
            //fail test
            var T = new TDDWork.MainWindow();
            string idTest = "12139";
            int flag = T.checkId(idTest);
            Assert.AreEqual(1, flag);
        }
        [WpfTestMethod]
        public void checkIdTest5()
        {
            //checkId possible outcomes : (-1) - notValid has non numeric chars
            //0 - valid , 1 - notValid incorrect num of chars(9),
            //2 - notValid id can't start with 0, 3 - empty string
            //fail test
            var T = new TDDWork.MainWindow();
            string idTest = "";
            int flag = T.checkId(idTest);
            Assert.AreEqual(3, flag);
        }


        //Student's first name tests
        [WpfTestMethod]
        public void checkFirstNameTest1()
        {
            //checkFirstName possible outcomes : true - valid name, only letters init,
            //false - invalid contains nonAlpha chars or empty string
            //succes test
            var T = new TDDWork.MainWindow();
            string nameTest = "Lidor";
            Boolean res= T.checkFirstName(nameTest);
            Assert.IsTrue(res);
        }
        [WpfTestMethod]
        public void checkFirstNameTest2()
        {
            //checkFirstName possible outcomes : true - valid name, only letters init,
            //false - invalid contains nonAlpha chars or empty string
            //success test
            var T = new TDDWork.MainWindow();
            string nameTest = "Lidor Jr";
            Boolean res = T.checkFirstName(nameTest);
            Assert.IsTrue(res);
        }
        [WpfTestMethod]
        public void checkFirstNameTest3()
        {
            //checkFirstName possible outcomes : true - valid name, only letters init,
            //false - invalid contains nonAlpha chars or empty string
            //fail test
            var T = new TDDWork.MainWindow();
            string nameTest = "Lidor34f";
            Boolean res = T.checkFirstName(nameTest);
            Assert.IsFalse(res);
        }
        [WpfTestMethod]
        public void checkFirstNameTest4()
        {
            //checkFirstName possible outcomes : true - valid name, only letters init,
            //false - invalid contains nonAlpha chars or empty string
            //fail test
            var T = new TDDWork.MainWindow();
            string nameTest = "JordanThe3";
            Boolean res = T.checkFirstName(nameTest);
            Assert.IsFalse(res);
        }
        [WpfTestMethod]
        public void checkFirstNameTest5()
        {
            //checkFirstName possible outcomes : true - valid name, only letters init,
            //false - invalid contains nonAlpha chars or empty string
            //fail test
            var T = new TDDWork.MainWindow();
            string nameTest = "";
            Boolean res = T.checkFirstName(nameTest);
            Assert.IsFalse(res);
        }


        //Student's surname tests
        [WpfTestMethod]
        public void checkSurNameTest1()
        {
            //checkSurName possible outcomes : true - valid name, only letters init,
            //false - invalid contains nonAlpha chars or empty string
            //success test
            var T = new TDDWork.MainWindow();
            string surnameTest = "Feldman";
            Boolean res = T.checkSurName(surnameTest);
            Assert.IsTrue(res);
        }
        [WpfTestMethod]
        public void checkSurNameTest2()
        {
            //checkSurName possible outcomes : true - valid name, only letters init,
            //false - invalid contains nonAlpha chars or empty string
            //success test
            var T = new TDDWork.MainWindow();
            string surnameTest = "Feldman Kur";
            Boolean res = T.checkSurName(surnameTest);
            Assert.IsTrue(res);
        }
        [WpfTestMethod]
        public void checkSurNameTest3()
        {
            //checkSurName possible outcomes : true - valid name, only letters init,
            //false - invalid contains nonAlpha chars or empty string
            //fail test
            var T = new TDDWork.MainWindow();
            string surnameTest = "Feld3man";
            Boolean res = T.checkSurName(surnameTest);
            Assert.IsFalse(res);
        }
        [WpfTestMethod]
        public void checkSurNameTest4()
        {
            //checkSurName possible outcomes : true - valid name, only letters init,
            //false - invalid contains nonAlpha chars or empty string
            //fail test
            var T = new TDDWork.MainWindow();
            string surnameTest = "1stFeldman@";
            Boolean res = T.checkSurName(surnameTest);
            Assert.IsFalse(res);
        }
        [WpfTestMethod]
        public void checkSurNameTest5()
        {
            //checkSurName possible outcomes : true - valid name, only letters init,
            //false - invalid contains nonAlpha chars or empty string
            //fail test
            var T = new TDDWork.MainWindow();
            string surnameTest = "";
            Boolean res = T.checkSurName(surnameTest);
            Assert.IsFalse(res);
        }


        //Student's email tests
        [WpfTestMethod]
        public void checkEmailTest1()
        {
            //email must contain @
            //checkEmail possible outcomes : 0 - valid email , (-1) - doesn't conatin @, 1 - empty string
            //success test
            var T = new TDDWork.MainWindow();
            string email = "dsadas@dsaas"; ;
            int flag=T.checkEmail(email);
            Assert.AreEqual(0, flag);
        }
        [WpfTestMethod]
        public void checkEmailTest2()
        {
            //email must contain @
            //checkEmail possible outcomes : 0 - valid email , (-1) - doesn't conatin @, 1 - empty string
            //success test
            var T = new TDDWork.MainWindow();
            string email = "@"; ;
            int flag = T.checkEmail(email);
            Assert.AreEqual(0, flag);
        }
        [WpfTestMethod]
        public void checkEmailTest3()
        {
            //email must contain @
            //checkEmail possible outcomes : 0 - valid email , (-1) - doesn't conatin @, 1 - empty string
            //fail test
            var T = new TDDWork.MainWindow();
            string email = ""; ;
            int flag = T.checkEmail(email);
            Assert.AreEqual(1, flag);
        }
        [WpfTestMethod]
        public void checkEmailTest4()
        {
            //email must contain @
            //checkEmail possible outcomes : 0 - valid email , (-1) - doesn't conatin @, 1 - empty string
            //fail test
            var T = new TDDWork.MainWindow();
            string email = "dsadasdsaas"; ;
            int flag = T.checkEmail(email);
            Assert.AreEqual(-1, flag);
        }



        //Student's phone number tests
        [WpfTestMethod]
        public void checkPhoneNumberTest1()
        {
            //checkPhoneNumber possible outcomes : (-1) - empty string, 0 - valid number,
            //1 - contains non numeric char, 2 - length is not 10, 3 - number doesn't start with 05
            //success test
            var T = new TDDWork.MainWindow();
            string numberTest = "0501112223";
            int flag = T.checkPhoneNumber(numberTest);
            Assert.AreEqual(0, flag);
        }
        [WpfTestMethod]
        public void checkPhoneNumberTest2()
        {
            //checkPhoneNumber possible outcomes : (-1) - empty string, 0 - valid number,
            //1 - contains non numeric char, 2 - length is not 10, 3 - number doesn't start with 05
            //fail test
            var T = new TDDWork.MainWindow();
            string numberTest = "05011123";
            int flag = T.checkPhoneNumber(numberTest);
            Assert.AreEqual(2, flag);
        }
        [WpfTestMethod]
        public void checkPhoneNumberTest3()
        {
            //checkPhoneNumber possible outcomes : (-1) - empty string, 0 - valid number,
            //1 - contains non numeric char, 2 - length is not 10, 3 - number doesn't start with 05
            //success test
            var T = new TDDWork.MainWindow();
            string numberTest = "050@12223";
            int flag = T.checkPhoneNumber(numberTest);
            Assert.AreEqual(1, flag);
        }
        [WpfTestMethod]
        public void checkPhoneNumberTest4()
        {
            //checkPhoneNumber possible outcomes : (-1) - empty string, 0 - valid number,
            //1 - contains non numeric char, 2 - length is not 10, 3 - number doesn't start with 05
            //success test
            var T = new TDDWork.MainWindow();
            string numberTest = "1501112223";
            int flag = T.checkPhoneNumber(numberTest);
            Assert.AreEqual(3, flag);
        }
        [WpfTestMethod]
        public void checkPhoneNumberTest5()
        {
            //checkPhoneNumber possible outcomes : (-1) - empty string, 0 - valid number,
            //1 - contains non numeric char, 2 - length is not 10, 3 - number doesn't start with 05
            //success test
            var T = new TDDWork.MainWindow();
            string numberTest = "";
            int flag = T.checkPhoneNumber(numberTest);
            Assert.AreEqual(-1, flag);
        }



        //Student's grades tests
        [WpfTestMethod]
        public void checkGradeTest1()
        {
            //checkGrade possible outcomes - (-1) - empty string, 0 - valid, 1 - not convertable to double,2 - not valid grade
            //the grade will be added to the grades array of the student only if it is convertable to double
            //fail test
            var T = new TDDWork.MainWindow();
            string gradeTest = "";
            int flag=T.checkGrade(gradeTest);
            Assert.AreEqual(-1, flag);
        }
        [WpfTestMethod]
        public void checkGradeTest2()
        {
            //checkGrade possible outcomes - (-1) - empty string, 0 - valid, 1 - not convertable to double,2 - not valid grade
            //2 - convertable but not in valid grade
            //the grade will be added to the grades array of the student only if it is convertable to double
            //fail and succes test
            var T = new TDDWork.MainWindow();
            string gradeTest = "100";
            int flag = T.checkGrade(gradeTest);
            string gradeTest2 = "100.1";
            int flag2 = T.checkGrade(gradeTest2);
            Assert.AreEqual(0, flag);
            Assert.AreEqual(2, flag2);
        }
        [WpfTestMethod]
        public void checkGradeTest3()
        {
            //checkGrade possible outcomes - (-1) - empty string, 0 - valid, 1 - not convertable to double,2 - not valid grade
            //the grade will be added to the grades array of the student only if it is convertable to double
            //fail and success test
            var T = new TDDWork.MainWindow();
            string gradeTest = "0";
            int flag = T.checkGrade(gradeTest);
            string gradeTest2 = "-1";
            int flag2 = T.checkGrade(gradeTest2);
            Assert.AreEqual(0, flag);
            Assert.AreEqual(2, flag2);

        }
        [WpfTestMethod]
        public void checkGradeTest4()
        {
            //checkGrade possible outcomes - (-1) - empty string, 0 - valid, 1 - not convertable to double,2 - not valid grade3
            //the grade will be added to the grades array of the student only if it is convertable to double
            //fail test
            var T = new TDDWork.MainWindow();
            string gradeTest = "12#";
            int flag = T.checkGrade(gradeTest);
            Assert.AreEqual(1, flag);
        }


        //Sort students algorithm tests
        [WpfTestMethod]
        public void sortStudentsTest1()
        {
            var T = new TDDWork.MainWindow();
            Student a = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 50, 60, 70, 777, 90 });
            Student b = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 76, 21, 77, 777, 100 });
            Student c = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 43, 87, 777, 12, 95 });
            Student d = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 96, 45, 34, 12, 100 });
            Student e = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 55, 86, 23, 777, 777 });
            Student f = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 12, 43, 777, 777, 777 });
            List < Student > arrTest = new List<Student>
            {
                a,//54
                b,//54.8
                c,//47.4
                d,//57.4
                e,//32.8
                f//11
            };
            arrTest.Sort((x,y)=>y.get_GPA().CompareTo(x.get_GPA()));
            List<Student> arr=T.sortStudents(new List<Student>(arrTest));
            Assert.AreEqual(6, arr.Count);//array size
            Assert.AreEqual(arrTest[0].get_GPA(), arr[0].get_GPA());
            Assert.AreEqual(arrTest[1].get_GPA(), arr[1].get_GPA());
            Assert.AreEqual(arrTest[2].get_GPA(), arr[2].get_GPA());
            Assert.AreEqual(arrTest[3].get_GPA(), arr[3].get_GPA());
            Assert.AreEqual(arrTest[4].get_GPA(), arr[4].get_GPA());
            Assert.AreEqual(arrTest[5].get_GPA(), arr[5].get_GPA());
            CollectionAssert.AreEqual(arrTest, arr);
        }
        [WpfTestMethod]
        public void sortStudentsTest2()
        {
            //fail test,checking current array against sorted from sortStudents method
            var T = new TDDWork.MainWindow();
            Student a = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 50, 60, 70, 777, 90 });
            Student b = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 76, 21, 77, 777, 100 });
            Student c = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 43, 87, 777, 12, 95 });
            Student d = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 96, 45, 34, 12, 100 });
            Student e = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 55, 86, 23, 777, 777 });
            Student f = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 12, 43, 777, 777, 777 });
            List<Student> arrTest = new List<Student>
            {
                a,//54
                b,//54.8
                c,//47.4
                d,//57.4
                e,//32.8
                f//11
            };
            //arrTest.Sort((x, y) => x.get_GPA().CompareTo(y.get_GPA()));
            List<Student> arr = T.sortStudents(new List<Student>(arrTest));
            Assert.AreEqual(6, arr.Count);//array size
            Assert.AreNotEqual(arrTest[0].get_GPA(), arr[0].get_GPA());
            Assert.AreEqual(arrTest[1].get_GPA(), arr[1].get_GPA());//stayed at the same spot
            Assert.AreNotEqual(arrTest[2].get_GPA(), arr[2].get_GPA());
            Assert.AreNotEqual(arrTest[3].get_GPA(), arr[3].get_GPA());
            Assert.AreEqual(arrTest[4].get_GPA(), arr[4].get_GPA());//stayed at the same spot
            Assert.AreEqual(arrTest[5].get_GPA(), arr[5].get_GPA());//stayed at the same spot
            CollectionAssert.AreNotEqual(arrTest, arr);
        }
        [WpfTestMethod]
        public void sortStudentsTest3()
        {
            //fail test, checking sorted current array against sorted array from sortStudents method, expecting different size of array
            var T = new TDDWork.MainWindow();
            Student a = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 50, 60, 70, 777, 90 });
            Student b = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 76, 21, 77, 777, 100 });
            Student c = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 43, 87, 777, 12, 95 });
            Student d = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 96, 45, 34, 12, 100 });
            Student e = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 55, 86, 23, 777, 777 });
            Student f = new Student("123456789", "Lidor", "Feldman", "sadsa@dsafd", "1234556", new double[] { 12, 43, 777, 777, 777 });
            List<Student> arrTest = new List<Student>
            {
                a,//54
                b,//54.8
                c,//47.4
                d,//57.4
                e,//32.8
                f//11
            };
            arrTest.Sort((x, y) => y.get_GPA().CompareTo(x.get_GPA()));
            List<Student> arr = T.sortStudents(new List<Student>(arrTest));
            Assert.AreNotEqual(5, arr.Count);//array size
            Assert.AreEqual(arrTest[0].get_GPA(), arr[0].get_GPA());
            Assert.AreEqual(arrTest[1].get_GPA(), arr[1].get_GPA());
            Assert.AreEqual(arrTest[2].get_GPA(), arr[2].get_GPA());
            Assert.AreEqual(arrTest[3].get_GPA(), arr[3].get_GPA());
            Assert.AreEqual(arrTest[4].get_GPA(), arr[4].get_GPA());
            Assert.AreEqual(arrTest[5].get_GPA(), arr[5].get_GPA());
            CollectionAssert.AreEqual(arrTest, arr);
        }
    }
}