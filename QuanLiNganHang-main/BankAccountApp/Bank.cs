using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BankAccountApp
{
    public class Bank
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }

        public Bank(string name)
        {
            Name = name;
            Accounts = new List<Account>();
        }

        // CRUD
        public void Add(Account acc) { Accounts.Add(acc); }

        public bool Remove(string number)
        {
            var acc = this[number];
            if (acc == null) return false;
            Accounts.Remove(acc);
            return true;
        }

        public Account this[string number]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(number)) return null;
                number = number.Trim(); // chặn lỗi space
                return Accounts.FirstOrDefault(a => a.Number == number);
            }
        }

        public List<Account> FindByOwner(string owner)
        {
            return Accounts.Where(a => a.Owner.IndexOf(owner, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public List<Account> FindByBalanceRange(double min, double max)
        {
            return Accounts.Where(a => a.Balance >= min && a.Balance <= max).ToList();
        }

        public void SortByBalanceDesc()
        {
            Accounts = Accounts.OrderByDescending(a => a.Balance).ToList();
        }

        public void ApplyMonthlyInterest()
        {
            foreach (var acc in Accounts) acc.ApplyMonthlyInterest();
        }

        // CSV helpers
        public void LoadFromCsv(string path)
        {
            if (!File.Exists(path)) return;

            var lines = File.ReadAllLines(path);
            Accounts.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                if (parts.Length < 4) continue;

                string number = parts[0];
                string owner = parts[1];

                if (!double.TryParse(parts[2], out double bal)) continue;
                if (!DateTime.TryParse(parts[3], out DateTime opened)) continue;

                var acc = new Account(number, owner, bal);
                acc.GetType().GetProperty("OpenedAt")
                   .SetValue(acc, opened); // gán lại ngày mở từ file

                Accounts.Add(acc);
            }
        }

        public void SaveToCsv(string path)
        {
            var rows = new List<string>();
            rows.Add("Number,Owner,Balance,OpenedAt"); // header

            foreach (var a in Accounts)
            {
                rows.Add($"{a.Number},{a.Owner},{a.Balance},{a.OpenedAt:yyyy-MM-dd}");
            }

            File.WriteAllLines(path, rows);
        }
        public bool IsEmpty()
        {
            return Accounts.Count == 0;
        }
    }
}
