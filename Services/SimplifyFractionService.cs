using System.Collections.Generic;
using System.Linq;

namespace Exercises.Services
{
    public class SimplifyFractionService : ISimplifyFractionService
    {
        private IList<Student> _students;

        public SimplifyFractionService()
        {
            _students = new List<Student>();

            var student1 = new Student(){
                Id = 1,
                Name = "Jon Doe",
                Grade = "1"
            };

            var student2 = new Student(){
                Id = 2,
                Name = "Alice",
                Grade = "3"
            };

            var student3 = new Student(){
                Id = 3,
                Name = "Bob",
                Grade = "2"
            };

            _students.Add(student1);
            _students.Add(student2);
            _students.Add(student3);
        }

        public bool AddStudent(Student student)
        {
            if(student != null)
            {
                _students.Add(student);
                return true;
            }

            return false;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public string ReduceFraction(int nbrNumerator, int nbrDenominator){
            try{
                int [] elements = {nbrNumerator,nbrDenominator};
                if (nbrDenominator != 0){
                    return Simplify(elements);
                }
                else
                {
                    MyException e = new MyException("Denominator cannot be zero");
                    throw e;
                }
                
            }
            catch (MyException e){
                return e.Message;
            }
            
        }

        private string Simplify(int[] numbers)
        {
            int gcd = GreatestCommomDivisor(numbers);
            int nbrNumerator, nbrDenominator;
            double operationResult;
            string fractionResult;
            
            for (int i = 0; i < numbers.Length; i++){
                numbers[i] /= gcd;
            }
            
            nbrNumerator = numbers[0];
            nbrDenominator = numbers[1];
            operationResult = (double)nbrNumerator/nbrDenominator;
            
            if (IsInteger(operationResult)){
                fractionResult = operationResult.ToString();
            }
            else{
                if (operationResult > (double)0){
                    if(nbrNumerator < 0) nbrNumerator = -nbrNumerator;
                    if(nbrDenominator < 0) nbrDenominator = -nbrDenominator;
                    fractionResult = nbrNumerator + "/" + nbrDenominator;
                }
                else{
                    fractionResult = "-" + nbrNumerator + "/" + nbrDenominator;
                }   
                
            }
            return fractionResult;
        }
        private bool IsInteger(double Nbr)
        {
            if(Nbr == (int)Nbr) return true;
            else return false;
        }
        private int GreatestCommomDivisor(int nbrNumerator, int nbrDenominator)
        {
            if(nbrNumerator < 0) nbrNumerator = -nbrNumerator; 
            if(nbrDenominator < 0) nbrDenominator = -nbrDenominator;

            while (nbrNumerator != 0 && nbrDenominator != 0)
            {
                if (nbrNumerator > nbrDenominator)
                    nbrNumerator %= nbrDenominator;
                else
                    nbrDenominator %= nbrNumerator;
            }
            return nbrNumerator | nbrDenominator;
        }
        private int GreatestCommomDivisor(int[] args)
        {
            return args.Aggregate((gcd, arg) => GreatestCommomDivisor(gcd, arg));
        }

        //  function ReduceFraction(){
        //     var nbrNumerator = $("#nbrNumerator").val();
        //     var nbrDenominator = $("#nbrDenominator").val();
        //     var operationResult;

        //     var gcd = function gcd(a,b){
        //         return b ? gcd(b, a%b) : a;
        //     };
        //     gcd = gcd(nbrNumerator,nbrDenominator);
        //     var finalNumerator = [nbrNumerator/gcd];
        //     var finalDenominator = [nbrDenominator/gcd];
        //     operationResult = finalNumerator / finalDenominator;
        //     if (!isNaN(finalDenominator)){
        //     if (Number.isInteger(operationResult)){
        //         $("#txtResult").val(operationResult);
        //     }
        //     else{
        //         $("#txtResult").val(finalNumerator + "/" + finalDenominator);    
        //     }
        //     }
        //     else{
        //     alert("Denominator cannot be zero");
        //     $("#txtResult").val("");
        //     }
        // }
    }
}