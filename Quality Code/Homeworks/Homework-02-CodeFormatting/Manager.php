<?php namespace League\CLImate\Settings;

class Manager {
    protected $settings = [];

    public function exists($name) {
        return class_exists($this->getPath($name));
    }

    public function add($name, $value){
        $setting = $this->getPath($name);
        $key = $this->getClassName($name);

        if (!array_key_exists($name, $this->settings)) {
            $this->settings[$key] = new $setting();
        }

        $this->settings[$key]->add($value);
    }

    public function get($key)
    {
        if (array_key_exists($key, $this->settings)) {
            return $this->settings[$key];
        }

        return false;
    }

    protected function getPath($name) {
        return '\\League\CLImate\\Settings\\' . $this->getClassName($name);
    }

    protected function getClassName($name){
        return ucwords(str_replace('add_', '', $name));
    }

	public function settings(){
        return [];
    }

    public function importSetting($setting) {
        $short_name = basename(str_replace('\\', '/', get_class($setting)));
        $method = 'importSetting' . $short_name;

        if (method_exists($this, $method)) {
            $this->$method($setting);
        }
    }
}