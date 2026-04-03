-- Assignment 1: Workbench Basics
-- -----------------------------------------------------------
create database StudentDB;
USE StudentDB;


-- Assignment 2: Table Operations
-- -----------------------------------------------------------
Create table Courses(
	course_id INT PRIMARY KEY,
    course_name VARCHAR(50),
    duration INT
);

Create table Students(
	student_id INT PRIMARY KEY,
    name VARCHAR(50),
    age INT,
    gender VARCHAR(10),
    course_id INT,
    FOREIGN KEY (course_id) REFERENCES courses(course_id)
);

CREATE TABLE Marks(
	mark_id INT PRIMARY KEY,
    student_id INT,
    subject VARCHAR(50),
    score INT,
    FOREIGN KEY (student_id) REFERENCES students(student_id)
);

ALTER TABLE students
ADD COLUMN email VARCHAR(50);

DROP TABLE Marks;


-- Assignment 3: DML Operations
-- -----------------------------------------------------------
INSERT INTO courses (course_id, course_name, duration)
VALUES
    (101, 'Computer Science', 4),
    (102, 'Mechanical Engineering', 4),
    (103, 'Electrical Engineering', 4),
    (104, 'Civil Engineering', 4),
    (105, 'Information Technology', 3);


INSERT INTO students (student_id,name, age, gender, course_id)
VALUES 
    (1,'A', 20, 'F', 101),
    (2,'B', 22, 'M', 102),
    (3,'C', 19, 'M', 103),
    (4,'D', 21, 'F', 101),
    (5,'E', 23, 'M', 104);
    

INSERT INTO marks (mark_id, student_id, subject, score)
VALUES
    (6, 1, 'Computer Science', 85),
    (2, 2, 'Physics', 78),
    (3, 3, 'Chemistry', 92),
    (4, 4, 'Computer Science', 88),
    (5, 5, 'English', 74);
    

UPDATE students
SET course_id = 105 WHERE student_id = 4;

DELETE FROM students
WHERE student_id = 5;


-- Assignment 4: Data Retrieval
-- -----------------------------------------------------------
SELECT 
    *
FROM
    students
WHERE
    age > 20;


SELECT 
    *
FROM
    students
ORDER BY name;


SELECT 
    c.course_name, COUNT(student_id) std_count
FROM
    students s
        RIGHT JOIN
    courses c ON s.course_id = c.course_id
GROUP BY c.course_name , c.course_id;


SELECT 
    c.course_name, COUNT(student_id) std_count
FROM
    students s
        RIGHT JOIN
    courses c ON s.course_id = c.course_id
GROUP BY c.course_name , c.course_id
HAVING std_count >= 2;


-- Assignment 5: Joins + Aggregates
-- -----------------------------------------------------------
SELECT 
    s.name, c.course_name
FROM
    students s
        INNER JOIN
    courses c ON s.course_id = c.course_id;


SELECT 
    s.name, c.course_name
FROM
    students s
        LEFT JOIN
    courses c ON s.course_id = c.course_id;


SELECT 
    s.name, c.course_name
FROM
    students s
        RIGHT JOIN
    courses c ON s.course_id = c.course_id;


SELECT 
    c.course_name,
    MAX(m.score) highest,
    MIN(m.score) lowest,
    AVG(m.score) average
FROM
    students s
        RIGHT JOIN
    courses c ON s.course_id = c.course_id
        INNER JOIN
    marks m ON s.student_id = m.student_id
GROUP BY c.course_name , c.course_id;


SELECT 
    SUM(gender = 'M') AS MALE, SUM(gender = 'F') AS FEMALE
FROM
    students;


-- Assignment 6: Subqueries
-- -----------------------------------------------------------
SELECT 
    *
FROM
    students s
        INNER JOIN
    marks m ON s.student_id = m.student_id
WHERE
    m.score > (SELECT 
            AVG(score)
        FROM
            marks);


SELECT 
    *
FROM
    students
WHERE
    course_id = (SELECT 
            course_id
        FROM
            students
        WHERE
            name = 'A');
            
            
-- Assignment 7: UNION & Set Ops
-- -----------------------------------------------------------

SELECT 
    course_name
FROM
    courses 
UNION SELECT 
    subject
FROM
    marks;


SELECT 
    course_name
FROM
    courses 
UNION ALL SELECT 
    subject
FROM
    marks;


-- Assignment 8: Constraints & Performance
-- -----------------------------------------------------------

Alter table students
ADD primary key (student_id);

Alter table courses
MODIFY column course_id INT auto_increment; 

Explain SELECT 
    *
FROM
    students
WHERE
    email = 'abc@gmail.com';

CREATE index email
on students(email);


Explain SELECT 
    *
FROM
    students
WHERE
    email = 'abc@gmail.com';

-- Assignment 9: Stored Programs
-- -----------------------------------------------------------


DELIMITER $$

create procedure find_students(
	IN course varchar(50)
)
begin 
	Select * From students s
    inner join courses c
    on s.course_id = c.course_id
    Where c.course_name = course;
end$$

DELIMITER ;


Call find_students('Civil Engineering');

DELIMITER $$

Create function temp(marks int)
returns VARCHAR(10)
DETERMINISTIC
begin
	
	if marks>90 then 
		return ('A');
    elseif marks>80 then 
		return ('B');
    else 
		return ('C');
    END IF;
end$$

DELIMITER ;

Select temp(90);

-- Assignment 10: Views 
-- -----------------------------------------------------------

CREATE VIEW StudentCourseView AS
    SELECT 
        s.name, c.course_name
    FROM
        students s
            INNER JOIN
        courses c ON s.course_id = c.course_id;
        
Select * From StudentCourseView
where course_name = 'Computer Science';