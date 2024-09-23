class InventarioFormularioController {

    onBtnGuardarClick(event) {

        event.preventDefault();

        const inventario = {
            "coD_CIA": document.getElementById('COD_CIA').value,
            "companiA_VENTA_3": document.getElementById('COMPANIA_VENTA_3').value,
            "almaceN_VENTA": document.getElementById('ALMACEN_VENTA').value,
            "tipO_MOVIMIENTO": document.getElementById('TIPO_MOVIMIENTO').value,
            "tipO_DOCUMENTO": document.getElementById('TIPO_DOCUMENTO').value,
            "nrO_DOCUMENTO": document.getElementById('NRO_DOCUMENTO').value,
            "coD_ITEM_2": document.getElementById('COD_ITEM_2').value
        }

        fetch(`${window.location.origin}/inventario/crear`, {
            method: 'POST',
            body: JSON.stringify(inventario),
            headers: { 'Content-Type': 'application/json' }
        })
            .then(response => response.json())
            .then(data => {

                const eventoInventarioGuardado = new CustomEvent('inventarioGuardado', { detail: data });
                document.dispatchEvent(eventoInventarioGuardado);

            });      

        return false;

    }


}