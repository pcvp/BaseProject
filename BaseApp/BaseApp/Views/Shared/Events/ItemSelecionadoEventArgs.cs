using System;

namespace BaseApp.Views.Shared.Events {
    public class ItemSelecionadoEventArgs : EventArgs {

        public ItemSelecionadoEventArgs() {
        }

        public ItemSelecionadoEventArgs(object itemSelecionado) {
            ItemSelecionado = itemSelecionado;
        }

        public object ItemSelecionado { get; set; }
    }
}