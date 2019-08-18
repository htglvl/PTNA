using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _selection, _selectionNotNull;
    bool show = false;


    private void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (Input.GetKeyDown(KeyCode.F))
                {
                    show = true;
                    if (_selectionNotNull != null)
                    {
                        if (_selectionNotNull.GetComponent<ruler>() != null)
                        {
                            //_selectionNotNull.GetComponent<stat>().selec = false;
                            _selectionNotNull.GetComponent<ruler>().selec = false;
                        }
                        if (_selectionNotNull.GetComponent<stat>() != null)
                        {
                            //_selectionNotNull.GetComponent<ruler>().selec = false;
                            _selectionNotNull.GetComponent<stat>().selec = false;
                        }
                    }
                    _selectionNotNull = selection;
                }
                if (selectionRenderer != null)
                {
                    defaultMaterial = selectionRenderer.material;
                    selectionRenderer.material = highlightMaterial;
                }
                _selection = selection;
            }
        }
        if (show == true)
        {
            if (_selectionNotNull.GetComponent<ruler>() != null)
            {
                //_selectionNotNull.GetComponent<stat>().selec = false;
                _selectionNotNull.GetComponent<ruler>().selec = true;
            }
            if (_selectionNotNull.GetComponent<stat>() != null)
            {
                //_selectionNotNull.GetComponent<ruler>().selec = false;
                _selectionNotNull.GetComponent<stat>().selec = true;
            }
        }
    }
}