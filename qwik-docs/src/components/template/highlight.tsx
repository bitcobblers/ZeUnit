import { component$ } from "@builder.io/qwik";

export default component$((props : { code : string, language : string, theme: any}) => {
  return (    
      <pre>
      <code class={`language-${props.language} ${props.theme}`} dangerouslySetInnerHTML={props.code} >        
      </code>    
      </pre>
  );
});