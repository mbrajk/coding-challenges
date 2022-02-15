namespace Implementation;

public class Node
{
    public int value { get; set; }
    public int key { get; set; }
    public Node next { get; set; }
    public Node prev { get; set; }
}

public class LRUCache
{
    private readonly int _capacity;
    private Node _head;
    private Node _tail;
    private Dictionary<int, Node> _cache;
    private int _currentSize;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _head = new Node();
        _tail = new Node();
        
        _head.next = _tail;
        _tail.prev = _head;
        
        _cache = new Dictionary<int, Node>(_capacity);
        _currentSize = 0;
    }

    private int GetFromCache(int key)
    {
        if (!_cache.ContainsKey(key))
        {
            return -1;
        }

        var cachedNode = _cache[key];

        RemoveNode(cachedNode);
        
        var newNode = new Node
        {
            key = key,
            value = cachedNode.value
        };
        
        AddNode(newNode);
        
        _cache[key] = newNode;
        
        return cachedNode.value;
    }

    private void AddNode(Node newNode)
    {
        newNode.next = _head.next;
        newNode.prev = _head;
        
        _head.next.prev = newNode;
        _head.next = newNode;
    }

    private void UpdateCache(int key, int value)
    {
        Node updateNode;
        if (_cache.ContainsKey(key))
        {
            updateNode = _cache[key];
            updateNode.value = value;
            
            RemoveNode(updateNode);
            AddNode(updateNode);
        }
        else
        {
            updateNode = new Node
            {
                key = key,
                value = value
            };
            
            AddNode(updateNode);

            _cache[key] = updateNode;
            _currentSize++;
            
            if (_currentSize > _capacity)
            {
                var tail = _tail.prev;
                tail.prev.next = _tail;
                _tail.prev = tail.prev;
                _cache.Remove(tail.key);
            }
        }
    }

    private void RemoveNode(Node node)
    {
        var next = node.next;
        var prev = node.prev;

        next.prev = prev;
        prev.next = next;
    }

    public int Get(int key)
    {
        return GetFromCache(key);
    }

    public void Put(int key, int value)
    {
        UpdateCache(key, value);
    }
}