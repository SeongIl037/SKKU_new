using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinqTest : MonoBehaviour
{
    private void Start()
    {
        List<Student> students = new List<Student>()
        {
            new Student() { Name = "허정범", Age = 28, Gender = "남" },
            new Student() { Name = "박수현", Age = 26, Gender = "여" },
            new Student() { Name = "박진혁", Age = 29, Gender = "남" },
            new Student() { Name = "이상진", Age = 28, Gender = "남" },
            new Student() { Name = "서민주", Age = 25, Gender = "여" },
            new Student() { Name = "전태준", Age = 27, Gender = "남" },
            new Student() { Name = "박순홍", Age = 27, Gender = "남" },
            new Student() { Name = "양성일", Age = 29, Gender = "남" }
        };
        
        // '컬렉션' 에서 '데이터'를 '조회' 하는 일이 많다.
        // c#은 이런 번번한 작업을 편하게 하기 위해 LINQ 문법을 만듬
        //Language Intergrated Queryty
        // 쿼리 : 질의 (데이터를 요청하거나 검색하는 명령문)
        
        // "from , in , select, where "
        // 이렇게는 잘 쓰이지 않음
        var all = from student in students select student;
        all = students.Where((student) => true);
        // 둘이 똑같다.
        foreach (var item in all)
        {
            Debug.Log(item);
        }

        
        
        var mans = from student in students where student.Gender == "남" select student;
        mans = students.Where((student) => student.Gender == "남");
        foreach (var item in mans)
        {
            Debug.Log(item);
        }
        
        var mans2 = from student in students 
            where student.Gender == "남"
            orderby student.Age ascending // descending
            select student;
        mans2 = students.Where((student) =>student.Gender == "남").OrderBy(student => student.Age);
        // OrderBy => 기본이 오름차순 
        foreach (var item in mans2)
        {
            Debug.Log(item);
        }
        // group by, join => 이 존재
        // 장점 : 편리하고 가독성이 좋다.
        // 단점 : IEnumerable은 내부적으로 커서를 만드는데 이것이 나중에 쓰레기가 된다.
        // ㄴ 메모리가 증가한다.
        // ㄴ 쓰면 참 좋은데.. 유니티 Update에서 사용은 비추!
        int mansCount = students.Count(student => student.Gender == "남");
        Debug.Log($" 남자 학생의 수 : {mansCount}");
        
        int totalAge = students.Sum(student => student.Age);
        Debug.Log($" 나이의 총합 : {totalAge}");
        
        double averageAge = students.Average(student => student.Age);
        
        // 조건 만족 : All(모두가 만족) vs Any (하나 이상이 만족)
        bool isAllMan = students.All(student => student.Gender == "남");
        
        bool is30 = students.Any(student => student.Age == 30);
        
        // sort 내장 함수는 내부적으로 마이크로 소프트가 이름 지어준 인트로 소트를 사용한다.
        // 인트로 소트 : 데이터의 크기, 종류 등의 성질에 따라 Quick,Heap, Radix Sort를 적절히 쓰는 기법이다.
        

    }
}
