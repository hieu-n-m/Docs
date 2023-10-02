namespace PracticeProject1
{
	internal class Officer
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public bool Sex { get; set; }
		public string Address { get; set; }

		public Officer(string name, int age, bool sex, string address)
		{
			Name = name;
			Age = age;
			Sex = sex;
			Address = address;
		}

		public override string ToString()
		{
			string tempS = Sex ? "male" : "female"; 
			return "\nName: " + Name +
				"\nAge: " + Age +
				"\nSex: " + tempS + 
				"\nAddress: " + Address;
		}
	}
}