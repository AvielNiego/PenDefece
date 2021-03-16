using Tile;
using TMPro;
using UnityEngine;

namespace Editor
{
    [ExecuteAlways]
    [RequireComponent(typeof(TextMeshPro))]
    public class CoordinateLabeler : MonoBehaviour
    {
        [SerializeField] Color defaultColor = Color.white;
        [SerializeField] Color blockedColor = Color.gray;
        
        private TextMeshPro label;
        private Vector2Int coordinates;
        private Waypoint waypoint;

        private void Awake()
        {
            label = GetComponent<TextMeshPro>();
            label.enabled = false;
            
            waypoint = GetComponentInParent<Waypoint>();
            
            UpdateCoordinates();
            DisplayCoordinates();
        }

        private void Update()
        {
            if (!Application.isPlaying)
            {
                UpdateCoordinates();
                DisplayCoordinates();
                UpdateObjectName();
            }
            
            ColorCoordinates();
            ToggleLabels();
        }

        private void ToggleLabels()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                label.enabled = !label.enabled;
            }
        }

        private void ColorCoordinates()
        {
            label.color = waypoint.IsPlaceable ? defaultColor : blockedColor;
        }

        private void UpdateObjectName()
        {
            transform.parent.name = coordinates.ToString();
        }

        private void DisplayCoordinates()
        {
            label.text = $"{coordinates.x}, {coordinates.y}";
        }

        private void UpdateCoordinates()
        {
            var parentPosition = transform.parent.position;
            var editorSnapSettingsMove = UnityEditor.EditorSnapSettings.move;

            coordinates.x = Mathf.RoundToInt(parentPosition.x / editorSnapSettingsMove.x);
            coordinates.y = Mathf.RoundToInt(parentPosition.z / editorSnapSettingsMove.z);
        }
    }
}
