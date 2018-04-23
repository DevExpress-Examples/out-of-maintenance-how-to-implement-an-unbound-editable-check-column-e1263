using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnboundCheckColumn {
    public class TestData {
        public List<TestDataItem> List { get; private set;}
        public TestData() {
            List<TestDataItem> list = new List<TestDataItem>();
            for(int i = 0; i < 20; i++) {
                list.Add(new TestDataItem() { Id = Guid.NewGuid(), Number = i });
            }
            List = list;
        }
    }
    public class TestDataItem {
        public Guid Id { get; set; }
        public int Number { get; set; }
    }
}
