using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenSkinDesigner.Logic
{
    public class cCommandQueue
    {
        private LinkedList<cCommand> pQueue;
        private LinkedListNode<cCommand> pLastAction;

        // A delegate type for hooking up change notifications.
        public delegate void EventHandler(cCommand sender, EventArgs e);

        public delegate void UndoRedoHandler(bool sender, EventArgs e);
        public event UndoRedoHandler UndoPossibleEvent;
        public event UndoRedoHandler RedoPossibleEvent;

        public class cCommand
        {
            // An event that clients can use to be notified
            public event EventHandler DoEvent;
            public event EventHandler UndoEvent;

            public String Info;

            public Object Helper;
            public Object Helper2;

            public Object From;
            public Object To;

            public cCommand(String info)
            {
                Info = info;
            }

            public virtual String toString()
            {
                // Enter here your command
                Console.WriteLine("CQ: toString");
                return "unkown";
            }

            public bool doCmd()
            {
                Console.WriteLine("CQ: do   " + Info);

                DoEvent(this, EventArgs.Empty);

                return false;
            }

            public bool undoCmd()
            {
                Console.WriteLine("CQ: undo " + Info);

                UndoEvent(this, EventArgs.Empty);

                return false;
            }
        }

        public cCommandQueue()
        {
            pQueue = new LinkedList<cCommand>();
            pLastAction = pQueue.First;

            isPossible();
        }

        public void addSilentCmd(cCommand cmd)
        {
            clearRedo();

            pQueue.AddLast(cmd);

            pLastAction = pQueue.Last;

            isPossible();
        }

        public void addCmd(cCommand cmd)
        {
            addSilentCmd(cmd);
            pLastAction.Value.doCmd();
        }

        public void undoCmd()
        {
            if (pLastAction != null)
            {
                pLastAction.Value.undoCmd();
                if (pLastAction != null)
                    pLastAction = pLastAction.Previous;
                RedoPossibleEvent(true, EventArgs.Empty); // Redo possible
            }

            isPossible();
        }

        public void redoCmd()
        {
            if (pLastAction == null)
            {
                pLastAction = pQueue.First;
                if (pLastAction != null)
                    pLastAction.Value.doCmd();
            }
            else if (pLastAction != null && pLastAction.Next != null)
            {
                pLastAction = pLastAction.Next;
                pLastAction.Value.doCmd();
            }

            isPossible();
        }

        private void isPossible() {
            if (RedoPossibleEvent != null)
                RedoPossibleEvent(isRedoPossible(), EventArgs.Empty);
            if (UndoPossibleEvent != null)
                UndoPossibleEvent(isUndoPossible(), EventArgs.Empty);
        }

        public bool isUndoPossible()
        {
            if (pLastAction != null)
                return true;
            return false;
        }

        public bool isRedoPossible()
        {
            if ((pLastAction != null && pLastAction.Next == null) || pQueue.First == null)
                return false;
            return true;
        }

        public void clear()
        {
            pQueue.Clear();
            pLastAction = pQueue.First;

            isPossible();
        }

        public void clearRedo()
        {
            while (pQueue.Last != pLastAction)
                pQueue.RemoveLast(); ;

            isPossible();
        }

        public void clearUndo()
        {
            while (pQueue.First != pLastAction)
                pQueue.RemoveFirst();

            if (pQueue.First != null)
                pQueue.RemoveFirst();

            pLastAction = pQueue.First;

            isPossible();
        }
    }
}
