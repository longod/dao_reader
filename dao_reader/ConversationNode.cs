// (c) hikami, aka longod
using System;
using System.Collections.Generic;
using System.Text;

namespace dao_reader {
    public class ConversationNode : System.Windows.Forms.TreeNode {
        public uint index;
        public uint id;
        public string speaker;
        public string listener;
        public uint[] children;
        public string conversation;
        public bool start = false;

        public ConversationNode DeepClone() {
            ConversationNode node = ( ConversationNode )this.Clone();
            node.index = this.index;
            node.id = this.id;
            node.speaker = this.speaker;
            node.listener = this.listener;
            node.children = this.children;
            node.Text = this.Text;
            node.conversation = this.conversation;
            node.start = this.start;
            return node;
        }
    }

}
