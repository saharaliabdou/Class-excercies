﻿using System;
using System.Collections.Generic;

namespace Kata2a_Inheritance
{
    class MemberList : IMemberList
    {
        List<IMember> _members = new List<IMember>();

        public IMember this[int idx]
        {
            get { return _members[idx]; }
        }
        public int Count() => _members.Count;
        public int Count(int year)
        {
            int c = 0;
            foreach (var item in _members)
            {
                if (item.Since.Year == year)
                    c++;
            }
            return c;
        }

        public void Sort() => _members.Sort();

        public override string ToString()
        {
            string sRet = "";
            for (int i = 0; i < _members.Count; i++)
            {
                sRet += $"{_members[i]}\n";
                if ((i + 1) % 10 == 0)
                {
                    sRet += "\n";
                }
            }
            return sRet;
        }

        #region Class Factory for creating an instance filled with Random data
        internal static class Factory
        {
            internal static IMemberList CreateWithRandomData(int NrOfItems)
            {
                var memberlist = new MemberList();
                for (int i = 0; i < NrOfItems; i++)
                {
                    memberlist._members.Add(Member.Factory.CreateWithRandomData());
                }
                return memberlist;
            }
        }
        #endregion

        public MemberList() { }
    }
}
