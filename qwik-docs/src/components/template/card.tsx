import { Slot, component$ } from "@builder.io/qwik";

export default component$(({title }: { title: string }) => {
    return (
      <div class="flex rounded-3xl p-3  dark:ring-1 dark:ring-slate-300/10">        
        <div class="flex-0 text-4xl">
          <Slot name="icon" />
        </div>
        <div class="ml-4 flex-auto">
          <p class={`m-0 mb-2.5 font-display text-xl text-sky-900 dark:text-sky-400 ${!title && "hidden"}`}>
            {title}
          </p>
          <div class="text-sky-800 [--tw-prose-background:theme(colors.sky.50)] prose-a:text-sky-900 prose-code:text-sky-900 dark:text-slate-300 dark:prose-code:text-slate-300">
            <Slot />
          </div>
        </div>
      </div>
    )
  });