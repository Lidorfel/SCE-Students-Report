using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;



namespace TDDWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private List<Student> studentsArray;
        private static long ID_COUNTER = 99999999;
        private HashSet<String> idSet;
        public MainWindow()
        {
            InitializeComponent();
            //CreateAndBindDataGridColumns();
            studentsArray = new List<Student>();
            idSet = new HashSet<String>();
            reportGrid.ItemsSource=studentsArray;
            studentCount.Text = studentsArray.Count.ToString("#,##0");
            studentCount2.Text = studentsArray.Count.ToString("#,##0");


        }

        private void addStudent_Click(object sender, RoutedEventArgs e)
        {
            collapseAll();
            string stFirstName = firstName.Text.Trim();
            string stSurName = surName.Text.Trim();
            string stEmail = email.Text.Trim();
            string stId = ID.Text.Trim();
            string stPhoneNumber = phoneNumber.Text.Trim();
            string stGrade1 = grade1.Text.Trim();
            string stGrade2 = grade2.Text.Trim();
            string stGrade3 = grade3.Text.Trim();
            string stGrade4 = grade4.Text.Trim();
            string stGrade5 = grade5.Text.Trim();
            int flag;
            Boolean flag2;
            Boolean res = true;
            flag2 = checkFirstName(stFirstName);
            if (!flag2)
            {
                res = false;
                firstNameError.Text = "שם פרטי חייב להכיל אותיות";
                firstNameError.Visibility = Visibility.Visible;
            }
            flag2 = checkSurName(stSurName);
            if (!flag2)
            {
                res = false;
                surNameError.Text = "שם משפחה חייב להכיל אותיות";
                surNameError.Visibility = Visibility.Visible;
            }
            flag = checkId(stId);
            if (flag == 3)
            {
                res = false;
                IDError.Text = "תוכן ריק";
                IDError.Visibility = Visibility.Visible;
            }
            else if (flag == 1)
            {
                res = false;
                IDError.Text = "מספר תעודת זהות מכיל 9 מספרים";
                IDError.Visibility = Visibility.Visible;
            }
            else if (flag == 2)
            {
                res = false;
                IDError.Text = "מספר תעודת זהות לא מתחיל ב0";
                IDError.Visibility = Visibility.Visible;
            }
            else if (flag == -1)
            {
                res = false;
                IDError.Text = "מספר תעודת זהות מכיל רק מספרים";
                IDError.Visibility = Visibility.Visible;
            }
            else if (flag == 4)
            {
                res = false;
                IDError.Text = "מס זה קיים כבר במערכת";
                IDError.Visibility = Visibility.Visible;
            }
            flag = checkEmail(stEmail);
            if (flag == 1)
            {
                res = false;
                emailError.Text = "תוכן ריק";
                emailError.Visibility = Visibility.Visible;
            }
            else if (flag == -1)
            {
                res = false;
                emailError.Text = "@ אימייל צריך להכיל";
                emailError.Visibility = Visibility.Visible;
            }
            flag = checkPhoneNumber(stPhoneNumber);
            if (flag == 1)
            {
                res = false;
                phoneNumberError.Text = "חייב להכיל רק מספרים";
                phoneNumberError.Visibility = Visibility.Visible;
            }
            else if (flag == -1)
            {
                res = false;
                phoneNumberError.Text = "תוכן ריק";
                phoneNumberError.Visibility = Visibility.Visible;
            }
            else if (flag == 2)
            {
                res = false;
                phoneNumberError.Text = "חייב להכיל 10 ספרות";
                phoneNumberError.Visibility = Visibility.Visible;
            }
            else if (flag == 3)
            {
                res = false;
                phoneNumberError.Text = "חייב להתחיל ב05";
                phoneNumberError.Visibility = Visibility.Visible;
            }
            flag = checkGrade(stGrade1);
            if (flag == 1)
            {
                res = false;
                grade1Error.Text = "לא מספר";
                grade1Error.Visibility = Visibility.Visible;
            }
            else if (flag == -1)
            {
                res = false;
                grade1Error.Text= "תוכן ריק";
                grade1Error.Visibility = Visibility.Visible;
            }
            else if(flag == 2)
            {
                res = false;
                grade1Error.Text = "ציון לא תקין";
                grade1Error.Visibility = Visibility.Visible;
            }
            flag = checkGrade(stGrade2);
            if (flag == 1)
            {
                res = false;
                grade2Error.Text = "לא מספר";
                grade2Error.Visibility = Visibility.Visible;
            }
            else if (flag == -1)
            {
                res = false;
                grade2Error.Text = "תוכן ריק";
                grade2Error.Visibility = Visibility.Visible;
            }
            else if (flag == 2)
            {
                res = false;
                grade2Error.Text = "ציון לא תקין";
                grade2Error.Visibility = Visibility.Visible;
            }
            flag = checkGrade(stGrade3);
            if (flag == 1)
            {
                res = false;
                grade3Error.Text = "לא מספר";
                grade3Error.Visibility = Visibility.Visible;
            }
            else if (flag == -1)
            {
                res = false;
                grade3Error.Text = "תוכן ריק";
                grade3Error.Visibility = Visibility.Visible;
            }
            else if (flag == 2)
            {
                res = false;
                grade3Error.Text = "ציון לא תקין";
                grade3Error.Visibility = Visibility.Visible;
            }
            flag = checkGrade(stGrade4);
            if (flag == 1)
            {
                res = false;
                grade4Error.Text = "לא מספר";
                grade4Error.Visibility = Visibility.Visible;
            }
            else if (flag == -1)
            {
                res = false;
                grade4Error.Text = "תוכן ריק";
                grade4Error.Visibility = Visibility.Visible;
            }
            else if (flag == 2)
            {
                res = false;
                grade4Error.Text = "ציון לא תקין";
                grade4Error.Visibility = Visibility.Visible;
            }
            flag = checkGrade(stGrade5);
            if (flag == 1)
            {
                res = false;
                grade5Error.Text = "לא מספר";
                grade5Error.Visibility = Visibility.Visible;
            }
            else if (flag == -1)
            {
                res = false;
                grade5Error.Text = "תוכן ריק";
                grade5Error.Visibility = Visibility.Visible;
            }
            else if (flag == 2)
            {
                res = false;
                grade5Error.Text = "ציון לא תקין";
                grade5Error.Visibility = Visibility.Visible;
            }
            if (res)
            {
                collapseAll();
                double[] grades=new double[] {Convert.ToDouble(stGrade1), Convert.ToDouble(stGrade2), Convert.ToDouble(stGrade3), Convert.ToDouble(stGrade4),Convert.ToDouble(stGrade5)};
                studentsArray.Add(new Student(stId, stFirstName, stSurName, stEmail, stPhoneNumber, grades));
                idSet.Add(stId);
                addStudentSuccess.Text = "סטודנט נוסף בהצלחה";
                addStudentError.Visibility = Visibility.Collapsed;
                addStudentSuccess.Visibility = Visibility.Visible;
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(5);
                timer.Tick += (sender, e) =>
                {
                    addStudentSuccess.Text = "";
                };
                timer.Start();
                emptyTextAll();
            }
            else
            {
                addStudentError.Text = "אחד או יותר פרטים לא חוקיים";
                addStudentSuccess.Visibility = Visibility.Collapsed;
                addStudentError.Visibility = Visibility.Visible;
            }
            reportGrid.Visibility = Visibility.Collapsed;
            showReport.Visibility = Visibility.Visible;
            sortTimer.Visibility = Visibility.Collapsed;
            studentCount.Text = studentsArray.Count.ToString("#,##0");
            studentCount2.Text = studentsArray.Count.ToString("#,##0");
        }

        private void generateStudents_Click(object sender, RoutedEventArgs e)
        {
            studentCount.Text = studentsArray.Count.ToString("#,##0");
            studentCount2.Text = studentsArray.Count.ToString("#,##0");
            try
            {
                for (int i = 0; i < 10000; i++)
                {
                    studentsArray.Add(generateStudent());
                }
                generateSuccess.Text = "נוספו בהצלחה 10,000 סטודנטים למערכת";
                generateSuccess.Visibility = Visibility.Visible;
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(5);
                timer.Tick += (sender, e) =>
                {
                    generateSuccess.Text = "";
                };
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("אירעה שגיאה, לא נוספו סטודנטים");
            }
            reportGrid.Visibility = Visibility.Collapsed;
            showReport.Visibility = Visibility.Visible;
            sortTimer.Visibility = Visibility.Collapsed;
            studentCount.Text = studentsArray.Count.ToString("#,##0");
            studentCount2.Text = studentsArray.Count.ToString("#,##0");
        }
        private void showReport_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Student> sortedArr = sortStudents(studentsArray);
            sortTimer.Visibility = Visibility.Visible;
            DataTable pDt = toDataTable(sortedArr);
            reportGrid.ItemsSource = pDt.DefaultView;
            reportGrid.Visibility = Visibility.Visible;
            showReport.Visibility = Visibility.Collapsed;
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            sortTimer.Text = "Sorting took " + elapsedTime.TotalSeconds + " seconds. for "+sortedArr.Count.ToString("#,##0") + " lines.";
        }
        private Student generateStudent()
        {
            
            Random random = new Random();
            string stPhoneNumber = "05";
            string[] possibleFNames = { "Mohamad","Lidor", "Avi", "Noa", "Moshe", "Itay", "Yehonatan", "Tal", "Matan", "Osnat", "Ofek", "Gal", "Asi", "Idan", "Tomer", "Nir", "Cristiano", "Lionel" };
            string[] possibleSNames = { "Abu Jafer","Feldman", "Shtal", "Kurland", "Cohen", "Levi", "Zadorov", "Shabtay", "Biton", "Dahari", "Amar", "Yifrah", "Kakou", "Kanimach", "Ronaldo", "Messi" };
            string[] possibleEmail = { "@gmail.com", "@Yahoo.com", "@Walla.com", "@AOL.com", "@Outlook.com" };
            int index1, index2, index3;
            
            for (int i=0;i<8;i++)
            {
                stPhoneNumber += random.NextInt64(0, 10).ToString();
            }
            index1 = random.Next(0, possibleFNames.Length);
            index2 = random.Next(0, possibleSNames.Length);
            index3 = random.Next(0, possibleEmail.Length);
            string stFName = possibleFNames[index1];
            string stSName = possibleSNames[index2];
            string stEmail = stFName.Replace(" ", "") + stSName.Replace(" ", "") + random.NextInt64(0, 100).ToString() + possibleEmail[index3];
            while (idSet.Contains(ID_COUNTER.ToString()))
            {
                ID_COUNTER++;
            }
            string stID= ID_COUNTER.ToString();
            ID_COUNTER++;
            double[] stGrades=new double[5];
            for (int i = 0; i < 5; i++)
            {
                double grade = random.NextDouble() * 110;
                if (grade > 100)
                    grade = 777;
                stGrades[i] = grade;
            }
            idSet.Add(stID);
            return new Student(stID, stFName, stSName, stEmail, stPhoneNumber, stGrades); 
        }
        private void collapseAll()
        {
            firstNameError.Visibility = Visibility.Collapsed;
            surNameError.Visibility = Visibility.Collapsed;
            emailError.Visibility = Visibility.Collapsed;
            IDError.Visibility = Visibility.Collapsed;
            phoneNumberError.Visibility = Visibility.Collapsed;
            grade1Error.Visibility = Visibility.Collapsed;
            grade2Error.Visibility = Visibility.Collapsed;
            grade3Error.Visibility = Visibility.Collapsed;
            grade4Error.Visibility = Visibility.Collapsed;
            grade5Error.Visibility = Visibility.Collapsed;
        }
        private void emptyTextAll()
        {
            firstName.Text = "";
            surName.Text = "";
            email.Text = "";
            phoneNumber.Text = "";
            ID.Text = "";
            grade1.Text = "";
            grade2.Text = "";
            grade3.Text = "";
            grade4.Text = "";
            grade5.Text = "";
        }
        public int checkId(string id)
        {
            if (id.Length == 0)
                return 3;
            if (id.Length != 9)
                return 1;
            for (int i=0;i<id.Length; i++)
            {
                if (!(id.All(Char.IsDigit)))
                    return -1;
            }
            if (id[0] == '0')
                return 2;
            if (idSet.Contains(id))
                return 4;
            return 0;
            
        }
        public Boolean checkFirstName(string name)
        {
            if (name.Length == 0)
                return false;
            return name.All(c => Char.IsLetter(c) || c == ' ');
        }
        public Boolean checkSurName(string surname)
        {
            if (surname.Length == 0)
                return false;
            return surname.All(c => Char.IsLetter(c) || c == ' ');
        }
        public int checkEmail(string email)
        {
            if (email.Length == 0)
                return 1;
            if (!email.Contains('@'))
                return -1;
            return 0;
        }
        public int checkPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length == 0)
                return -1;
            if (!(phoneNumber.All(Char.IsDigit)))
                return 1;
            if (phoneNumber.Length != 10)
                return 2;
            if (phoneNumber.Substring(0, 2) != "05")
                return 3;
            return 0;
        }
        public int checkGrade(string grade)
        {
            if (grade.Length == 0)
                return -1;
            double conv;
            if (double.TryParse(grade, out conv))
            {
                if ((conv >= 0 && conv <= 100) || conv == 777)
                    return 0;
                else
                    return 2;
            }
            else
                return 1;
        }

        public List<Student> sortStudents(List<Student> studentsArray)
        {
            /*            //BubbleSort of the students, using operator overloading in Student's Class, highest GPA will be first
                        int len = studentsArray.Count;
                        for (int i = 0; i < len - 1; i++)
                        {
                            for (int j = 0; j < len- i - 1; j++)
                            {
                                if (studentsArray[j] < studentsArray[j + 1])
                                {
                                    Student temp = studentsArray[j];
                                    studentsArray[j] = studentsArray[j + 1];
                                    studentsArray[j + 1] = temp;
                                }
                            }
                        }
                        return studentsArray;*/

            //Merge-Sort
            if (studentsArray.Count <= 1)
            {
                return studentsArray;
            }

            int middleIndex = studentsArray.Count / 2;
            List<Student> leftList = new List<Student>();
            List<Student> rightList = new List<Student>();

            for (int i = 0; i < middleIndex; i++)
            {
                leftList.Add(studentsArray[i]);
            }

            for (int i = middleIndex; i < studentsArray.Count; i++)
            {
                rightList.Add(studentsArray[i]);
            }

            leftList = sortStudents(leftList);
            rightList = sortStudents(rightList);

            return Merge(leftList, rightList);
        }
        private List<Student> Merge(List<Student> leftList, List<Student> rightList)
        {
            List<Student> mergedList = new List<Student>();

            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < leftList.Count && rightIndex < rightList.Count)
            {
                if (leftList[leftIndex] > rightList[rightIndex])
                {
                    mergedList.Add(leftList[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    mergedList.Add(rightList[rightIndex]);
                    rightIndex++;
                }
            }

            while (leftIndex < leftList.Count)
            {
                mergedList.Add(leftList[leftIndex]);
                leftIndex++;
            }

            while (rightIndex < rightList.Count)
            {
                mergedList.Add(rightList[rightIndex]);
                rightIndex++;
            }

            return mergedList;
        }
        public List<Student> get_students()
        {
            return this.studentsArray;
        }
        private DataTable toDataTable(List<Student> students)
        {
            DataTable dataTable = new DataTable();

            // Add columns to the DataTable
            dataTable.Columns.Add("Index", typeof(string));
            dataTable.Columns.Add("First Name", typeof(string));
            dataTable.Columns.Add("Last Name", typeof(string));
            dataTable.Columns.Add("Student ID", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Phone Number", typeof(string));
            dataTable.Columns.Add("GPA", typeof(double));
            int count = 1;

            // Add rows to the DataTable
            foreach (Student student in students)
            {
                DataRow row = dataTable.NewRow();
                row["Index"] = count++.ToString("#,##0");
                row["Student ID"] = student.Id;
                row["First Name"] = student.firstName;
                row["Last Name"] = student.surName;
                row["Email"] = student.email;
                row["Phone Number"] = student.phoneNumber;
                row["GPA"] = student.GPA;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        private void deleteSt_Click(object sender, RoutedEventArgs e)
        {
            if (studentsArray.Count > 0)
            {
                studentsArray.Clear();
                studentCount.Text = studentsArray.Count.ToString("#,##0");
                studentCount2.Text = studentsArray.Count.ToString("#,##0");
                reportGrid.Visibility= Visibility.Collapsed;
                showReport.Visibility= Visibility.Visible;
                sortTimer.Visibility= Visibility.Collapsed;
            }
        }
    }
}
