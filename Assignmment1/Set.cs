using System;
namespace Assignmment1
{
	public class Set
	{
		public class DuplicateException : Exception { }
		public class IsNotInTheSet : Exception { }
		public class Empty : Exception { }

		private List<int> n;

		public Set()
		{
			this.n = new List<int>();
			/*int maxaux = n[0];
			
			for(int i =0; i<n.Count; i++)
			{
				if (maxaux < n[i]) maxaux = n[i]; 
			}*/
		}
		public Set(Set set)
		{
			this.n = set.n;
		}
		public void insert(int number)
		{
			for(int i =0; i < n.Count; i++)
			{
				if (n[i] == number) throw new DuplicateException();
			}
			n.Add(number);
        }
        public bool isEmpty()
        {
            if (this.n.Count == 0) return true;
            return false;
        }
        public void remove(int number)
		{
			if (n.Count==0) throw new Empty();
            if (!contains(number)) throw new IsNotInTheSet();
            n.Remove(number);
		}
		public bool contains(int number)
		{
            bool cont = false;
            if (n.Count==0) return cont;
			for (int i = 0; i < n.Count && !cont; i++)
			{
				if (n[i] == number) cont = true;
			}
			return cont;
		}
		public int random()
		{
			
			if (!n.Any()) throw new Empty();
			Random rn = new Random();
			int number = rn.Next(n.Count);

   			return n[number];
		}
		public int largest()
		{
			if (n.Count==0) throw new Empty();
			int max = n[0];
			for(int i =0; i<n.Count; i++)
			{
				if (max < n[i]) max = n[i];
			}
			return max;
		}
		public string print()
		{
			string start = "[";
			for (int i = 0; i < n.Count; i++)
			{
                start += n[i];
				if (i < n.Count - 1)
				{
					start += ",";
				}
            }start += "]";
			return start;
		}
	}
}