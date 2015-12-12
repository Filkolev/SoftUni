package empires.models.resources;

public enum ResourceType {

    GOLD("Gold"),
    STEEL("Steel");
    
    private final String value;
    
    ResourceType(String text) {
        this.value = text;
    }

    public static ResourceType fromString(String text) {
        if (text != null) {
            for (ResourceType rt : ResourceType.values()) {
                if (text.equalsIgnoreCase(rt.toString())) {
                    return rt;
                }
            }
        }

        throw new IllegalArgumentException("Unknown resoure type.");
    }
    
    public static String toString(ResourceType type) {
        return type.value;
    }
}
