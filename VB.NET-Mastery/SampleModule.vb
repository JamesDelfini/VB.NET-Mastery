Module SampleModule
    ' Using Classes 
    'Class Student
    '    ' Sample declaring of a standard variables in a class. Using public is not always recommended.
    '    Public firstName As String
    '    Public lastName As String
    '    Public DateOfBirth As String
    'End Class

    'Dim student1 As New Student
    'Sub Main()
    '    Dim selection As Char

    '    While selection <> "E"
    '        Console.WriteLine("Welcome to Student Database")
    '        Console.WriteLine()
    '        Console.WriteLine("[A] Add a Student")
    '        Console.WriteLine("[B] View Students")
    '        Console.WriteLine("[E] Exit")
    '        Console.WriteLine()

    '        selection = Console.ReadLine.ToUpper

    '        If selection = "A" Then
    '            Console.WriteLine("Please enter a First Name: ")
    '            student1.firstName = Console.ReadLine

    '            Console.WriteLine("Please enter a Surname: ")
    '            student1.lastName = Console.ReadLine

    '            Console.WriteLine("Please enter a Date of Birth: ")
    '            student1.DateOfBirth = Console.ReadLine
    '        ElseIf selection = "B" Then
    '            Console.WriteLine("First Name : " & student1.firstName)
    '            Console.WriteLine("Surname : " & student1.lastName)
    '            Console.WriteLine("Date of Birth : " & student1.DateOfBirth)
    '            Console.ReadLine()
    '            Console.Clear()
    '        End If
    '    End While
    'End Sub
    Class cStudent
        ' Recommended declaration of variables in a class.
        Private _firstName As String
        Private _surname As String
        Private _dateOfBirth As String

        Function getFullName()
            Return FirstName & Surname
        End Function

        Public Property FirstName As String
            Set(value As String)
                _firstName = value
            End Set
            Get
                Return _firstName
            End Get
        End Property

        Public Property Surname As String
            Set(value As String)
                _surname = value
            End Set
            Get
                Return _surname
            End Get
        End Property

        Public Property DateOfBirth As String
            Set(value As String)
                _dateOfBirth = value
            End Set
            Get
                Return _dateOfBirth
            End Get
        End Property
    End Class

    Sub Main()

        Dim student As New cStudent
        Dim selection As Char = Nothing

        While selection <> "E"
            Console.Clear()
            Console.WriteLine("Welcome to Student Database")
            Console.WriteLine()
            Console.WriteLine("[A] Add a Student")
            Console.WriteLine("[B] View Students")
            Console.WriteLine("[E] Exit")
            Console.WriteLine()
            selection = Console.ReadLine().ToUpper

            If selection = "A" Then
                Console.WriteLine("Enter for First Name: ")
                student.FirstName = Console.ReadLine()

                Console.WriteLine("Enter for Surname: ")
                student.Surname = Console.ReadLine()

                Console.WriteLine("Enter for Date of Birth: ")
                student.DateOfBirth = Console.ReadLine()
            ElseIf selection = "B" Then
                Console.WriteLine("First Name: " & student.FirstName)

                Console.WriteLine("Surname: " & student.Surname)

                Console.WriteLine("Date of Birth: " & student.DateOfBirth)
                Console.ReadLine()
                Console.Clear()
            End If
        End While
    End Sub
End Module
