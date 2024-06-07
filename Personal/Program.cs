using System.Text;

namespace Decorator.Personal
{
    interface IMedicalDocument
    {
        void Display();
    }

    class MedicalRecord : IMedicalDocument
    {
        private string patientName;
        private string diagnosis;

        public MedicalRecord(string patientName, string diagnosis)
        {
            this.patientName = patientName;
            this.diagnosis = diagnosis;
        }

        public void Display()
        {
            Console.WriteLine($"Пацієнт: {patientName}");
            Console.WriteLine($"Діагноз: {diagnosis}");
        }
    }

    abstract class Decorator : IMedicalDocument
    {
        protected IMedicalDocument decoratedDocument;

        public Decorator(IMedicalDocument decoratedDocument)
        {
            this.decoratedDocument = decoratedDocument;
        }

        public virtual void Display()
        {
            decoratedDocument.Display();
        }
    }

    class SecurityDecorator : Decorator
    {
        public SecurityDecorator(IMedicalDocument decoratedDocument) : base(decoratedDocument) { }

        public override void Display()
        {
            base.Display();
            AddSecurity();
        }

        private void AddSecurity()
        {
            Console.WriteLine("Безпековий рівень документа: Високий");
        }
    }

    class DoctorSignatureDecorator : Decorator
    {
        public DoctorSignatureDecorator(IMedicalDocument decoratedDocument) : base(decoratedDocument) { }

        public override void Display()
        {
            base.Display();
            AddDoctorSignature();
        }

        private void AddDoctorSignature()
        {
            Console.WriteLine("Підпис лікаря: Доктор Іванов");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IMedicalDocument medicalRecord = new MedicalRecord("Іванов Іван Іванович", "Грип");

            medicalRecord = new SecurityDecorator(medicalRecord);
            medicalRecord = new DoctorSignatureDecorator(medicalRecord);

            medicalRecord.Display();

            Console.ReadLine();
        }
    }
}
