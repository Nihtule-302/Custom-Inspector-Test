using UnityEngine;

[CreateAssetMenu(fileName = "Array2D", menuName = "Array2D")]
public class Array2D : ScriptableObject
{
    [SerializeField] private int rows = 3;
    [SerializeField] private int columns = 3;

    private int _cachedRows;
    private int _cachedColumns;
    
    [SerializeField] int[] array;

    private void OnEnable()
    {
        array = new int[rows * columns];
        _cachedColumns = columns;
        _cachedRows = rows;
    }

    private void OnValidate()
    {
        if (rows!=_cachedRows || columns!=_cachedColumns)
        {
            _cachedRows = rows;
            _cachedColumns = columns;
            array = new int[rows * columns];
            
        }
    }
}
