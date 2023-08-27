public class Text {
    String text;
    public Text() {
        text = "";
    }
    public Text(String text) {
        this.text = text;
    }
    public String standardize () {
        if (text.isBlank() || text.isEmpty()) {
            return "";
        }
        return text.replaceAll("\\s+", " ").strip();
    }
    public int countWord () {
        if (text.isEmpty() || text.isBlank()) {
            return 0;
        }
        return standardize().split("\\s").length;
    }
}
